using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            try
            {
                string username = UsernameEntry.Text;
                string password = PasswordEntry.Text;

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    await DisplayAlert("Ошибка", "Пожалуйста, заполните все поля", "OK");
                    return;
                }

                if (username == "admin" && password == "password")
                {
                    await DisplayAlert("Успех", "Вы успешно вошли в систему", "OK");
                    await Navigation.PushAsync(new MainPage());
                }
                else
                {
                    await DisplayAlert("Ошибка", "Неверный логин или пароль", "OK");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                await DisplayAlert("Ошибка", "Произошла ошибка при входе", "OK");
            }
        }
    }
}
