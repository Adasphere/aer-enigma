// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeatherViewModel.cs" company="Adasphere">
//   2018
// </copyright>
// <summary>
//   Defines the WeatherViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AEREnigma.ViewModels
{
    using System;
    using System.Threading.Tasks;

    using AER.Enigma.Core.Services;
    using AER.Enigma.Core.Services.Design;

    using AEREnigma.Models;

    using GalaSoft.MvvmLight;

    /// <summary>
    /// The weather view model.
    /// </summary>
    public class WeatherViewModel : AdaViewModelBase<Weather>
    {
        /// <summary>
        /// Stores the weather service.
        /// </summary>
        private readonly IWeatherService weatherService;

        //private readonly Location location;

        /// <summary>
        /// Stores the humidity
        /// </summary>
        private double humidity;

        /// <summary>
        /// Stores the temperature
        /// </summary>
        private double temperature;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherViewModel"/> class.
        /// </summary>
        /// <param name="weatherService">
        /// The weather service.
        /// </param>
        public WeatherViewModel(IWeatherService weatherService, Location location) : base(location)
        {
            this.weatherService = weatherService;
            //this.location = location;
        }

#if DEBUG
        public WeatherViewModel()
        {
            if (IsInDesignMode)
            {
                IWeatherService service = new DesignWeatherService();
                this.Model = service.GetWeatherAsync(22903).GetAwaiter().GetResult();
            }
        }
#endif

        /// <summary>
        /// The base initialization method
        /// </summary>
        /// <param name="initData">
        /// Location initialization data
        /// </param>
        protected override async Task Initialize(object initData)
        {
            Location location = (Location)initData;

            if (location == null)
            {
                throw new ArgumentException($"Expecting a {typeof(Location).FullName} object");
            }

            this.Model = await this.GetWeatherAsync(location);
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);


        }

        /// <summary>
        /// Gets the weather asynchronously
        /// </summary>
        /// <param name="location">
        /// The location.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/> for getting the weather.
        /// </returns>
        private async Task<Weather> GetWeatherAsync(Location location)
        {
            Task<Weather> task  = this.weatherService.GetWeatherAsync(location.ZipCode);

            return await task;
        }

    }
}
