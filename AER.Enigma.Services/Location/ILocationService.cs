using System;
using System.Collections.Generic;
using System.Text;

namespace AER.Enigma.Services.Location
{
    using System.Threading.Tasks;

    using AER.Enigma.Models;
    using AER.Enigma.Models.Business;

    public interface ILocationService
    {
        Task UpdateUserLocation(Location location, string token);
    }
}
