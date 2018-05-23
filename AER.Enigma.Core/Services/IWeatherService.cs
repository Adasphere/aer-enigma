// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWeatherService.cs" company="Adasphere">
//   2018
// </copyright>
// <summary>
//   Interface contract for a service that obtains weather information.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AER.Enigma.Core.Services
{
    using System.Threading.Tasks;

    using AEREnigma.Models;

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
        Task<Weather> GetWeatherAsync(int zipCode);

        /// <summary>
        /// Asynchronously gets the weather for a given city
        /// </summary>
        /// <param name="city">The city</param>
        /// <returns><see cref="Task{T}"/> of <see cref="Weather"/></returns>
        Task<Weather> GetWeatherAsync(string city);
    }
}
