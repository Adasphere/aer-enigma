using System;
using System.Collections.Generic;
using System.Text;

namespace AER.Enigma.Services.Location
{
    using System.Threading;
    using System.Threading.Tasks;

    using AER.Enigma.Models;
    using AER.Enigma.Models.Business;

    public class LocationSearchService : ILocationSearchService
    {
        public Task<IEnumerable<Location>> SearchAsync(string term)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Location>> SearchAsync(string term, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
