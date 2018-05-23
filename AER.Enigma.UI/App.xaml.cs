using System;
using AER.Enigma.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace AER.Enigma.UI
{
    using AER.Enigma.UI.Helpers;
    using AER.Enigma.UI.Pages;
    using AER.Enigma.ViewModels;

    using GalaSoft.MvvmLight.Ioc;
    using GalaSoft.MvvmLight.Views;

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // First time initialization
            var nav = new NavigationService();
            nav.Configure(ViewModelLocator.WeatherPageKey, typeof(WeatherPage));

            SimpleIoc.Default.Register<INavigationService>(() => nav);

            var dialog = new DialogService();
            SimpleIoc.Default.Register<IDialogService>(() => dialog);

            var navPage = new NavigationPage(new SearchPage());

            nav.Initialize(navPage);
            dialog.Initialize(navPage);

            // The root page of your application
            MainPage = navPage;
        }
    }
}
