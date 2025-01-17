﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreditCalculatorPageFlyout : ContentPage
    {
        public ListView ListView;

        public CreditCalculatorPageFlyout()
        {
            InitializeComponent();

            BindingContext = new CreditCalculatorPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class CreditCalculatorPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<CreditCalculatorPageFlyoutMenuItem> MenuItems { get; set; }

            public CreditCalculatorPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<CreditCalculatorPageFlyoutMenuItem>(new[]
                {
                    new CreditCalculatorPageFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new CreditCalculatorPageFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new CreditCalculatorPageFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new CreditCalculatorPageFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new CreditCalculatorPageFlyoutMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}