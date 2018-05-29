using System;
using System.Collections.Generic;
using System.Text;

namespace AER.Enigma.Services.Design
{
    using System.Threading;
    using System.Threading.Tasks;

    using AER.Enigma.Models;
    using AER.Enigma.Models.Business;
    using AER.Enigma.Services.Location;

    public class DesignLocationSearchService : ILocationSearchService
    {
        Task<IEnumerable<Location>> ILocationSearchService.SearchAsync(string term)
        {
            return null;
        }

        Task<IEnumerable<Location>> ILocationSearchService.SearchAsync(string term, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
