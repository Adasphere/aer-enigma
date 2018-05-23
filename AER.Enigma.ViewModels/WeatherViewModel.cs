// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeatherViewModel.cs" company="Adasphere">
//   2018
// </copyright>
// <summary>
//   Defines the WeatherViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AER.Enigma.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AER.Enigma.Models;
    using AER.Enigma.Services;
    using AER.Enigma.Services.Design;

    /// <summary>
    /// The weather view model.
    /// </summary>
    public class WeatherViewModel : AdaViewModelBase<List<Weather>>
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
                Location location = new Location() { ZipCode = 22903 };
                IWeatherService service = new DesignWeatherService();
                this.Model = new List<Weather> { service.GetWeather(location) };
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
        private async Task<List<Weather>> GetWeatherAsync(Location location)
        {
            Task<List<Weather>> task  = this.weatherService.GetWeatherAsync(location);

            return await task;
        }

    }
}
