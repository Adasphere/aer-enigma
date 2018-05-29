using System;
using System.Collections.Generic;
using System.Text;

namespace AER.Enigma.Services.Location
{
    using System.Threading.Tasks;

    using AER.Enigma.Core;
    using AER.Enigma.Models;
    using AER.Enigma.Models.Business;

    public class LocationService : ILocationService
    {
        private readonly IRequestProvider _requestProvider;

        public LocationService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task UpdateUserLocation(Location location, string token)
        {
            UriBuilder builder = new UriBuilder(GlobalSetting.Instance.BaseEndpoint);
            builder.Path = "/mobilemarketingapigw/api/v1/l/locations";
            string uri = builder.ToString();
            await _requestProvider.PostAsync(uri, location, token);
        }
    }
}
