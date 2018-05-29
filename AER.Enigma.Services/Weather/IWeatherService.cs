// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWeatherService.cs" company="Adasphere">
//   2018
// </copyright>
// <summary>
//   Interface contract for a service that obtains weather information.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AER.Enigma.Services.Weather
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AER.Enigma.Models;
    using AER.Enigma.Models.Business;

    /// <summary>
    /// Interface contract for a service that obtains weather information.
    /// </summary>
    public interface IWeatherService
    {
        /// <summary>
        /// Asynchronously gets the weather for a given zip code
        /// </summary>
        /// <param name="zipCode">The zip code</param>
        /// <returns><see cref="Task{T}"/> of <see cref="Weather"/></returns>
        Weather GetWeather(Location location);

        /// <summary>
        /// Asynchronously gets the weather for a given city
        /// </summary>
        /// <param name="city">The city</param>
        /// <returns><see cref="Task{T}"/> of <see cref="Weather"/></returns>
        Task<List<Weather>> GetWeatherAsync(Location location);
    }
}
