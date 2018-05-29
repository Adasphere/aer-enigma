using System;
using System.Collections.Generic;
using System.Text;

namespace AER.Enigma.Services.Location
{
    using System.Threading;
    using System.Threading.Tasks;

    using AER.Enigma.Models;
    using AER.Enigma.Models.Business;

    public interface ILocationServiceImplementation
    {
        double DesiredAccuracy { get; set; }
        bool IsGeolocationAvailable { get; }
        bool IsGeolocationEnabled { get; }

        Task<Position> GetPositionAsync(TimeSpan? timeout = null, CancellationToken? token = null);
    }
}
