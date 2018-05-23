// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeatherService.cs" company="Adasphere">
//   2018
// </copyright>
// <summary>
//   Service for getting weather information
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AER.Enigma.Core.Services
{
    using System.Threading.Tasks;

    using AEREnigma.Models;

    /// <summary>
    /// Service for getting weather information
    /// </summary>
    public class WeatherService : IWeatherService
    {
        /// <summary>
        /// Asynchronously gets the weather for a given zip code.
        /// </summary>
        /// <param name="zipCode">
        /// The zip code with weather.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> of <see cref="Weather"/>.
        /// </returns>
        public async Task<Weather> GetWeatherAsync(int zipCode)
        {
            // Replace with an asynchronous call to a web service
            Task<Weather> task = Task<Weather>.Factory.StartNew(
                z =>
                    {
                        Weather weather = new Weather()
                                              {
                                                  Humidity = 50.5,
                                                  Temperature = 70.8
                                              };

                        return weather;
                    },
                zipCode);

            return await task;
        }

        /// <summary>
        /// Asynchronously gets the weather for a given zip code.
        /// </summary>
        /// <param name="city">
        /// The city with weather.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> of <see cref="Weather"/>.
        /// </returns>
        public async Task<Weather> GetWeatherAsync(string city)
        {
            // Replace with an asynchronous call to a web service
            Task<Weather> task = Task<Weather>.Factory.StartNew(
                c =>
                    {
                        Weather weather = new Weather()
                                              {
                                                  Humidity = 50.5,
                                                  Temperature = 70.8
                                              };

                        return weather;
                    },
                city);

            return await task;
        }
    }
}