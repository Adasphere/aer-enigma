// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeatherViewModel.cs" company="Adasphere">
//   2018
// </copyright>
// <summary>
//   Defines the WeatherViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AER.Enigma.UI.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using AER.Enigma.Models.Business;
    using AER.Enigma.Services.Database;
    using AER.Enigma.Services.Location;
    using AER.Enigma.Services.Weather;
    using AER.Enigma.UI.ViewModels.Base;
    using AER.Enigma.UI.ViewModels.Services;

    using Xamarin.Forms;

    /// <summary>
    /// The weather view model.
    /// </summary>
    public class WeatherViewModel : ViewModelBase
    {
        private ILocationSearchService locationSearchService;

        private IWeatherService weatherService;

        private readonly INavigationService navigationService;

        private readonly IDatabaseService databaseService;

        private ObservableCollection<Weather> weatherList;

        private ObservableCollection<Location> locations;

        private Location location;

        public WeatherViewModel(ILocationSearchService locationSearchService, IWeatherService weatherService, INavigationService navigationService, IDatabaseService databaseService)
        {
            this.locationSearchService = locationSearchService;
            this.weatherService = weatherService;
            this.navigationService = navigationService;
            this.databaseService = databaseService;
        }

        public ICommand SearchLocationCommand => new Command<string>(async (t) => await this.SearchLocation(t));

        public ICommand LocationSelectedCommand => new Command<Location>(async (l) => await this.LocationSelectedAsync(l));

        public ICommand ShowAlertCommand => new Command(async () => await this.ShowAlert());

        public Location Location
        {
            get
            {
                return this.location;
            }

            set
            {
                this.location = value;
                this.RaisePropertyChanged(() => this.Location);
            }
        }

        public ObservableCollection<Weather> WeatherList
        {
            get
            {
                return this.weatherList;
            }

            private set
            {
                this.weatherList = value;
                this.RaisePropertyChanged(() => this.WeatherList);
            }
        }

        public ObservableCollection<Location> Locations
        {
            get
            {
                return this.locations;
            }

            set
            {
                this.locations = value;
                this.RaisePropertyChanged(() => this.Locations);
            }
        }

        public override async Task InitializeAsync(object navigationData)
        {
            if (this.databaseService != null)
            {
                List<Weather> list = await this.databaseService.RetrieveWeatherAsync();
                if (list != null)
                {
                    this.WeatherList = new ObservableCollection<Weather>(list);
                }
            }

            await base.InitializeAsync(navigationData);
        }

        private async Task LocationSelectedAsync(Location location)
        {
            this.Location = location;
            List<Weather> list = await this.GetWeatherAsync(location);
            this.WeatherList = new ObservableCollection<Weather>(list);

            if (this.databaseService != null)
            {
                await this.databaseService.UpdateWeatherAsync(list);
            }
        }

        private async Task SearchLocation(string term)
        {
            IEnumerable<Location> list = await this.locationSearchService.SearchAsync(term);

            this.Locations = new ObservableCollection<Location>(list);
        }

        private async Task ShowAlert()
        {
            this.navigationService.NavigateToAsync<AlertViewModel>(this.Location);
        }

        //        /// <summary>
        //        /// Stores the weather service.
        //        /// </summary>
        //        private readonly IWeatherService weatherService;

        //        //private readonly Location location;

        //        /// <summary>
        //        /// Stores the humidity
        //        /// </summary>
        //        private double humidity;

        //        /// <summary>
        //        /// Stores the temperature
        //        /// </summary>
        //        private double temperature;

        //        /// <summary>
        //        /// Initializes a new instance of the <see cref="WeatherViewModel"/> class.
        //        /// </summary>
        //        /// <param name="weatherService">
        //        /// The weather service.
        //        /// </param>
        //        public WeatherViewModel(IWeatherService weatherService, Location location) : base(location)
        //        {
        //            this.weatherService = weatherService;
        //            //this.location = location;
        //        }

        //#if DEBUG
        //        public WeatherViewModel()
        //        {
        //            if (IsInDesignMode)
        //            {
        //                Location location = new Location() { ZipCode = 22903 };
        //                IWeatherService service = new DesignWeatherService();
        //                this.Model = new List<Weather> { service.GetWeather(location) };
        //            }
        //        }
        //#endif

        //        /// <summary>
        //        /// The base initialization method
        //        /// </summary>
        //        /// <param name="initData">
        //        /// Location initialization data
        //        /// </param>
        //        protected override async Task Initialize(object initData)
        //        {
        //            Location location = (Location)initData;

        //            if (location == null)
        //            {
        //                throw new ArgumentException($"Expecting a {typeof(Location).FullName} object");
        //            }

        //            this.Model = await this.GetWeatherAsync(location);
        //        }

        //        protected override void OnPropertyChanged(string propertyName)
        //        {
        //            base.OnPropertyChanged(propertyName);
        //        }

        /// <summary>
        /// Gets the weather asynchronously
        /// </summary>
        /// <param name="location">
        /// The location.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/> for getting the weather.
        /// </returns>
        private async Task<List<Weather>> GetWeatherAsync(Location location)
        {
            Task<List<Weather>> task = this.weatherService.GetWeatherAsync(location);

            return await task;
        }

    }
}
