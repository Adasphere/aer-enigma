using System;
using System.Collections.Generic;
using System.Text;

namespace AER.Enigma.Core.Services.Design
{
    using System.Threading;
    using System.Threading.Tasks;

    using AEREnigma.Models;

    public class DesignLocationSearchService : ILocationSearchService
    {
        public Task<IEnumerable<Location>> SearchAsync(string term)
        {
            return null;
        }

        public Task<IEnumerable<Location>> SearchAsync(string term, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
