using System;
using AER.Enigma.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace AER.Enigma.UI
{
    using System.Diagnostics;
    using System.Globalization;
    using System.Threading.Tasks;

    using AER.Enigma.Models.Business;
    using AER.Enigma.Services.Location;
    using AER.Enigma.UI.Services;
    using AER.Enigma.UI.ViewModels.Base;
    using AER.Enigma.UI.ViewModels.Services;
    using AER.Enigma.ViewModels.Services;


    public partial class App : Application
    {
        ISettingsService settingsService;

        private void RegisterServices()
        {
            ViewModelLocator.RegisterUIServices<ISettingsService, SettingsService>();
            ViewModelLocator.RegisterUIServices<IDependencyService, DependencyService>();
            ViewModelLocator.RegisterUIServices<INavigationService, NavigationService>();
            ViewModelLocator.RegisterUIServices<IDialogService, DialogService>();
        }
        public App()
        {
            InitializeComponent();

            MainPage = new ContentPage { Title = "App Lifecycle Sample" }; // your page here
            this.RegisterServices();
            InitApp();
            if (Device.RuntimePlatform == Device.UWP)
            {
                InitNavigation();
            }
        }

        private void InitApp()
        {
            this.settingsService = ViewModelLocator.Resolve<ISettingsService>();
            if (!this.settingsService.UseMocks)
                ViewModelLocator.UpdateDependencies(this.settingsService.UseMocks);
        }

        private Task InitNavigation()
        {
            var navigationService = ViewModelLocator.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        protected override async void OnStart()
        {
            base.OnStart();

            if (Device.RuntimePlatform != Device.UWP)
            {
                await InitNavigation();
            }
            if (this.settingsService.AllowGpsLocation && !this.settingsService.UseFakeLocation)
            {
                await GetGpsLocation();
            }
            if (!this.settingsService.UseMocks && !string.IsNullOrEmpty(this.settingsService.AuthAccessToken))
            {
                await SendCurrentLocation();
            }

            base.OnResume();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        private async Task GetGpsLocation()
        {
            var dependencyService = ViewModelLocator.Resolve<IDependencyService>();
            var locator = dependencyService.Get<ILocationServiceImplementation>();

            if (locator.IsGeolocationEnabled && locator.IsGeolocationAvailable)
            {
                locator.DesiredAccuracy = 50;

                try
                {
                    var position = await locator.GetPositionAsync();
                    this.settingsService.Latitude = position.Latitude.ToString();
                    this.settingsService.Longitude = position.Longitude.ToString();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
            else
            {
                this.settingsService.AllowGpsLocation = false;
            }
        }

        private async Task SendCurrentLocation()
        {
            var location = new Location
            {
                Latitude = double.Parse(this.settingsService.Latitude, CultureInfo.InvariantCulture),
                Longitude = double.Parse(this.settingsService.Longitude, CultureInfo.InvariantCulture)
            };

            var locationService = ViewModelLocator.Resolve<ILocationService>();
            await locationService.UpdateUserLocation(location, this.settingsService.AuthAccessToken);
        }
    }
}