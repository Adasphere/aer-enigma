﻿namespace AER.Enigma.UI.Pages
{
    using AER.Enigma.ViewModels;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        public SearchViewModel ViewModel
        {
            get
            {
                return (SearchViewModel)BindingContext;
            }
        }

        public WeatherPage()
        {
            InitializeComponent();

            BindingContext = ((ViewModelLocator)Application.Current.Resources["Locator"]).Search;

            this.results.ItemTapped += (s, e) => { ViewModel.SearchCommand.Execute(e.Item); };

        }
    }
}