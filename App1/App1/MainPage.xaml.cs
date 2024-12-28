using System;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnNavigateToCreditCalculator(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.CreditCalculatorPage());
        }
    }
}
