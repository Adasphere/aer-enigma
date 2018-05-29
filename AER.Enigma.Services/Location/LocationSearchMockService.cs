// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockLocationSearchService.cs" company="Adasphere">
//   2018
// </copyright>
// <summary>
//   Defines the MockLocationSearchService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AER.Enigma.Services.Location
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using AER.Enigma.Models;
    using AER.Enigma.Models.Business;

    /// <summary>
    /// The mock location search service.
    /// </summary>
    public sealed class LocationSearchMockService : ILocationSearchService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocationSearchMockService"/> class.
        /// </summary>
        public LocationSearchMockService()
        {
            this.Initialize();
        }

        /// <summary>
        /// Gets or sets the locations.
        /// </summary>
        private List<Location> Locations
        {
            get;
            set;
        }

        /// <summary>
        /// Asynchronously searches for locations given a a search term, first by zip code and then by city name.
        /// </summary>
        /// <param name="term">
        /// A zip code or city used to search locations.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> of <see cref="IEnumerable{T}"/> of <see cref="Location"/> objects that match the search term.
        /// </returns>
        public async Task<IEnumerable<Location>> SearchAsync(string term)
        {
            Task<IEnumerable<Location>> task = Task<IEnumerable<Location>>.Factory.StartNew(
                (t) =>
                    {
                        if (int.TryParse(t.ToString(), out int zipCode))
                        {
                            return this.Locations.Where(l => l.ZipCode == zipCode);
                        }
                        else
                        {
                            return this.Locations.Where(l => l.City == t.ToString());
                        }
                    }, 
                term);

            return await task;
        }

        /// <summary>
        /// Asynchronously searches for locations given a a search term, first by zip code and then by city name, and allows cancellation.
        /// </summary>
        /// <param name="term">
        /// A zip code or city used to search locations.
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> of <see cref="IEnumerable{T}"/> of <see cref="Location"/> objects that match the search term.
        /// </returns>
        public async Task<IEnumerable<Location>> SearchAsync(string term, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                // ReSharper disable once MethodSupportsCancellation
                return await this.SearchAsync(term);
            }
            catch (OperationCanceledException operationCanceledException)
            {
                Console.WriteLine(operationCanceledException);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            return null;
        }

        /// <summary>
        /// Initializes the search service.
        /// </summary>
        private void Initialize()
        {
            this.Locations = this.InitializeLocations();
        }

        /// <summary>
        /// Initializes the locations
        /// </summary>
        /// <returns>
        /// The <see cref="List{T}"/> of locations.
        /// </returns>
        private List<Location> InitializeLocations()
        {
            return new List<Location>
            {
                new Location
                {
                    City = "Waynesboro",
                    Country = "United States",
                    Latitude = 38.0685,
                    Longitude = -78.8895,
                    State = "VA",
                    ZipCode = 22980
                },
                new Location
                {
                    City = "Bedford",
                    Country = "United States",
                    Latitude = 42.9463,
                    Longitude = -71.5132,
                    State = "NH",
                    ZipCode = 03103
                },
                new Location
                {
                    City = "Charlottesville",
                    Country = "United States",
                    Latitude = 38.0293,
                    Longitude = -78.4767,
                    State = "VA",
                    ZipCode = 22903
                },
            };
        }
    }
}
