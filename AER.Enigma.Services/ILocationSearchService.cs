// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILocationSearchService.cs" company="Adasphere">
//   2018
// </copyright>
// <summary>
//   Interface contract for a service that performs locations searches.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AER.Enigma.Services
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using AER.Enigma.Models;

    /// <summary>
    /// Interface contract for a service that performs locations searches.
    /// </summary>
    public interface ILocationSearchService
    {
        /// <summary>
        /// Asynchronously searches for locations given a search term
        /// </summary>
        /// <param name="term">A zip code, city, or other term used to search locations.</param>
        /// <returns>A <see cref="Task{TResult}"/> of <see cref="IEnumerable{T}"/> of <see cref="Location"/> objects that match the search term.</returns>
        Task<IEnumerable<Location>> SearchAsync(string term);

        /// <summary>
        /// Asynchronously searches for locations given a search term and enables cancellation.
        /// </summary>
        /// <param name="term">A zip code, city, or other term used to search locations.</param>
        /// <param name="cancellationToken">A token used to cancel the search process.</param>
        /// <returns>A <see cref="Task{TResult}"/> of <see cref="IEnumerable{T}"/> of <see cref="Location"/> objects that match the search term.</returns>
        Task<IEnumerable<Location>> SearchAsync(string term, CancellationToken cancellationToken);
    }
}
