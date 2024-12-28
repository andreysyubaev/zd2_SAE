using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreditCalculatorPage : ContentPage
    {
        public CreditCalculatorPage()
        {
            InitializeComponent();
            InterestRateSlider.ValueChanged += InterestRateSlider_ValueChanged;
        }

        private void InterestRateSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            InterestRateLabel.Text = $"Процентная ставка: {e.NewValue:F1}%"; // Форматируем с 1 десятичным знаком
        }

        private async void CalculateButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Проверка на пустые поля
                if (string.IsNullOrWhiteSpace(LoanAmountEntry.Text) ||
                    string.IsNullOrWhiteSpace(LoanTermEntry.Text))
                {
                    await DisplayAlert("Ошибка", "Пожалуйста, заполните все поля", "OK");
                    return;
                }

                // Проверка ввода суммы кредита
                if (!double.TryParse(
                        LoanAmountEntry.Text.Replace(",", "."),
                        System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture,
                        out double loanAmount))
                {
                    await DisplayAlert("Ошибка", "Введите корректную сумму кредита", "OK");
                    return;
                }

                // Проверка ввода срока кредита
                if (!int.TryParse(LoanTermEntry.Text, out int loanTerm))
                {
                    await DisplayAlert("Ошибка", "Введите корректный срок кредита", "OK");
                    return;
                }

                // Проверка выбранного типа платежа
                if (PaymentTypePicker.SelectedIndex == -1)
                {
                    await DisplayAlert("Ошибка", "Выберите тип платежа", "OK");
                    return;
                }

                // Получение ставки процента
                double interestRate = InterestRateSlider.Value;
                string paymentType = PaymentTypePicker.SelectedItem.ToString();

                if (paymentType == "Аннуитетный")
                {
                    // Расчет аннуитетного платежа
                    double monthlyPayment = CalculateAnnuityPayment(loanAmount, interestRate, loanTerm);
                    double totalPayment = monthlyPayment * loanTerm;
                    double overpayment = totalPayment - loanAmount;

                    MonthlyPaymentLabel.Text = $"Ежемесячный платеж: {monthlyPayment:C}";
                    TotalPaymentLabel.Text = $"Общая сумма: {totalPayment:C}";
                    OverpaymentLabel.Text = $"Переплата: {overpayment:C}";
                }
                else
                {
                    // Для дифференцированного платежа
                    MonthlyPaymentLabel.Text = "Ежемесячный платеж: ";
                    TotalPaymentLabel.Text = "Общая сумма: ";
                    OverpaymentLabel.Text = "Переплата: ";
                }
            }
            catch (Exception ex)
            {
                // Логирование других ошибок
                Console.WriteLine($"Ошибка: {ex.Message}");
                await DisplayAlert("Ошибка", "Произошла ошибка при расчете", "OK");
            }
        }

        private double CalculateAnnuityPayment(double loanAmount, double interestRate, int loanTerm)
        {
            double monthlyInterestRate = (interestRate / 100) / 12;
            double annuityFactor = Math.Pow(1 + monthlyInterestRate, loanTerm);
            double monthlyPayment = (loanAmount * monthlyInterestRate * annuityFactor) / (annuityFactor - 1);
            return monthlyPayment;
        }
    }
}
