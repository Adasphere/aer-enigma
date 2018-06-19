namespace AER.Enigma.UI.ViewModels
{
    using System.Diagnostics;
    using System.Globalization;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using AER.Enigma.Core;
    using AER.Enigma.Models.Business;
    using AER.Enigma.Services.Location;
    using AER.Enigma.UI.ViewModels.Base;
    using AER.Enigma.UI.ViewModels.Services;

    using Xamarin.Forms;

    public class SettingsViewModel : ViewModelBase
    {
        private string _titleUseAzureServices;
        private string _descriptionUseAzureServices;
        private bool _useAzureServices;
        private string _titleUseFakeLocation;
        private string _descriptionUseFakeLocation;
        private bool _allowGpsLocation;
        private string _titleAllowGpsLocation;
        private string _descriptionAllowGpsLocation;
        private bool _useFakeLocation;
        private string _endpoint;
        private double _latitude;
        private double _longitude;
        private string _gpsWarningMessage;

        private readonly ISettingsService _settingsService;
        private readonly ILocationService _locationService;
        private readonly IDependencyService _dependencyService;

        public SettingsViewModel(ISettingsService settingsService, ILocationService locationService, IDependencyService dependencyService)
        {
            this._settingsService = settingsService;
            this._locationService = locationService;
            this._dependencyService = dependencyService;

            this._useAzureServices = !this._settingsService.UseMocks;
            this._endpoint = this._settingsService.UrlBase;
            this._latitude = double.Parse(this._settingsService.Latitude, CultureInfo.CurrentCulture);
            this._longitude = double.Parse(this._settingsService.Longitude, CultureInfo.CurrentCulture);
            this._useFakeLocation = this._settingsService.UseFakeLocation;
            this._allowGpsLocation = this._settingsService.AllowGpsLocation;
            this._gpsWarningMessage = string.Empty;
        }

        public string TitleUseAzureServices
        {
            get => this._titleUseAzureServices;
            set
            {
                this._titleUseAzureServices = value;
                this.RaisePropertyChanged(() => this.TitleUseAzureServices);
            }
        }

        public string DescriptionUseAzureServices
        {
            get => this._descriptionUseAzureServices;
            set
            {
                this._descriptionUseAzureServices = value;
                this.RaisePropertyChanged(() => this.DescriptionUseAzureServices);
            }
        }

        public bool UseAzureServices
        {
            get => this._useAzureServices;
            set
            {
                this._useAzureServices = value;

                this.UpdateUseAzureServices();

                this.RaisePropertyChanged(() => this.UseAzureServices);
            }
        }

        public string TitleUseFakeLocation
        {
            get => this._titleUseFakeLocation;
            set
            {
                this._titleUseFakeLocation = value;
                this.RaisePropertyChanged(() => this.TitleUseFakeLocation);
            }
        }

        public string DescriptionUseFakeLocation
        {
            get => this._descriptionUseFakeLocation;
            set
            {
                this._descriptionUseFakeLocation = value;
                this.RaisePropertyChanged(() => this.DescriptionUseFakeLocation);
            }
        }

        public bool UseFakeLocation
        {
            get => this._useFakeLocation;
            set
            {
                this._useFakeLocation = value;

                this.UpdateFakeLocation();

                this.RaisePropertyChanged(() => this.UseFakeLocation);
            }
        }

        public string TitleAllowGpsLocation
        {
            get => this._titleAllowGpsLocation;
            set
            {
                this._titleAllowGpsLocation = value;
                this.RaisePropertyChanged(() => this.TitleAllowGpsLocation);
            }
        }

        public string DescriptionAllowGpsLocation
        {
            get => this._descriptionAllowGpsLocation;
            set
            {
                this._descriptionAllowGpsLocation = value;
                this.RaisePropertyChanged(() => this.DescriptionAllowGpsLocation);
            }
        }

        public string GpsWarningMessage
        {
            get => this._gpsWarningMessage;
            set
            {
                this._gpsWarningMessage = value;
                this.RaisePropertyChanged(() => this.GpsWarningMessage);
            }
        }

        public string Endpoint
        {
            get => this._endpoint;
            set
            {
                this._endpoint = value;

                if (!string.IsNullOrEmpty(this._endpoint))
                {
                    this.UpdateEndpoint();
                }

                this.RaisePropertyChanged(() => this.Endpoint);
            }
        }

        public double Latitude
        {
            get => this._latitude;
            set
            {
                this._latitude = value;

                this.UpdateLatitude();

                this.RaisePropertyChanged(() => this.Latitude);
            }
        }

        public double Longitude
        {
            get => this._longitude;
            set
            {
                this._longitude = value;

                this.UpdateLongitude();

                this.RaisePropertyChanged(() => this.Longitude);
            }
        }

        public bool AllowGpsLocation
        {
            get => this._allowGpsLocation;
            set
            {
                this._allowGpsLocation = value;

                this.UpdateAllowGpsLocation();

                this.RaisePropertyChanged(() => this.AllowGpsLocation);
            }
        }

        public bool UserIsLogged => !string.IsNullOrEmpty(this._settingsService.AuthAccessToken);

        public ICommand ToggleMockServicesCommand => new Command(async () => await this.ToggleMockServicesAsync());

        public ICommand ToggleFakeLocationCommand => new Command(this.ToggleFakeLocationAsync);

        public ICommand ToggleSendLocationCommand => new Command(async () => await this.ToggleSendLocationAsync());

        public ICommand ToggleAllowGpsLocationCommand => new Command(this.ToggleAllowGpsLocation);

        public override Task InitializeAsync(object navigationData)
        {
            this.UpdateInfoUseAzureServices();
            this.UpdateInfoFakeLocation();
            this.UpdateInfoAllowGpsLocation();

            return base.InitializeAsync(navigationData);
        }

        private async Task ToggleMockServicesAsync()
        {
            ViewModelLocator.UpdateDependencies(!this.UseAzureServices);
            this.UpdateInfoUseAzureServices();

            var previousPageViewModel = this.NavigationService.PreviousPageViewModel;
            if (previousPageViewModel != null)
            {
                if (previousPageViewModel is MainViewModel)
                {
                    // Slight delay so that page navigation isn't instantaneous
                    await Task.Delay(1000);
                    if (this.UseAzureServices)
                    {
                        this._settingsService.AuthAccessToken = string.Empty;
                        this._settingsService.AuthIdToken = string.Empty;

                        // TODO: [Doug 5/24/2018] - Possible uncommment this code if login is desired
                        //await NavigationService.NavigateToAsync<LoginViewModel>(new LogoutParameter { Logout = true });
                        await this.NavigationService.RemoveBackStackAsync();
                    }
                }
            }
        }

        private void ToggleFakeLocationAsync()
        {
            ViewModelLocator.UpdateDependencies(!this.UseAzureServices);
            this.UpdateInfoFakeLocation();
        }

        private async Task ToggleSendLocationAsync()
        {
            if (!this._settingsService.UseMocks)
            {
                var locationRequest = new Location
                {
                    Latitude = this._latitude,
                    Longitude = this._longitude
                };
                var authToken = this._settingsService.AuthAccessToken;

                await this._locationService.UpdateUserLocation(locationRequest, authToken);
            }
        }

        private void ToggleAllowGpsLocation()
        {
            this.UpdateInfoAllowGpsLocation();
        }

        private void UpdateInfoUseAzureServices()
        {
            if (!this.UseAzureServices)
            {
                this.TitleUseAzureServices = "Use Mock Services";
                this.DescriptionUseAzureServices = "Mock Services are simulated objects that mimic the behavior of real services using a controlled approach.";
            }
            else
            {
                this.TitleUseAzureServices = "Use Microservices/Containers from aer-enigma";
                this.DescriptionUseAzureServices = "When enabling the use of microservices/containers, the app will attempt to use real services deployed as Docker containers at the specified base endpoint, which will must be reachable through the network.";
            }
        }

        private void UpdateInfoFakeLocation()
        {
            if (!this.UseFakeLocation)
            {
                this.TitleUseFakeLocation = "Use Real Location";
                this.DescriptionUseFakeLocation = "When enabling location, the app will attempt to use the location from the device.";

            }
            else
            {
                this.TitleUseFakeLocation = "Use Fake Location";
                this.DescriptionUseFakeLocation = "Fake Location data is added for marketing campaign testing.";
            }
        }

        private void UpdateInfoAllowGpsLocation()
        {
            if (!this.AllowGpsLocation)
            {
                this.TitleAllowGpsLocation = "GPS Location Disabled";
                this.DescriptionAllowGpsLocation = "When disabling location, you won't receive location campaigns based upon your location.";
            }
            else
            {
                this.TitleAllowGpsLocation = "GPS Location Enabled";
                this.DescriptionAllowGpsLocation = "When enabling location, you'll receive location campaigns based upon your location.";

            }
        }

        private void UpdateUseAzureServices()
        {
            // Save use mocks services to local storage
            this._settingsService.UseMocks = !this._useAzureServices;
        }

        private void UpdateEndpoint()
        {
            // Update remote endpoint (save to local storage)
            GlobalSettings.Instance.BaseEndpoint = this._settingsService.UrlBase = this._endpoint;
        }

        private void UpdateFakeLocation()
        {
            this._settingsService.UseFakeLocation = this._useFakeLocation;
        }

        private void UpdateLatitude()
        {
            // Update fake latitude (save to local storage)
            this._settingsService.Latitude = this._latitude.ToString();
        }

        private void UpdateLongitude()
        {
            // Update fake longitude (save to local storage)
            this._settingsService.Longitude = this._longitude.ToString();
        }

        private void UpdateAllowGpsLocation()
        {
            if (this._allowGpsLocation)
            {
                var locator = this._dependencyService.Get<ILocationServiceImplementation>();

                if (locator != null)
                {
                    if (!locator.IsGeolocationEnabled)
                    {
                        this._allowGpsLocation = false;
                        this.GpsWarningMessage = "Enable the GPS sensor on your device";
                    }
                    else
                    {
                        this._settingsService.AllowGpsLocation = this._allowGpsLocation;
                        this.GpsWarningMessage = string.Empty;
                    }

                }
                else
                {
                    Debug.WriteLine("AER.Enigma.UI.ViewModels.SettingsViewModel - Location service is not implemented on this platform.");
                }
            }
            else
            {
                this._settingsService.AllowGpsLocation = this._allowGpsLocation;
            }
        }
    }
}
