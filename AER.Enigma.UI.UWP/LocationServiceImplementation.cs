using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using AER.Enigma.UI.UWP;
using AER.Enigma.Services.Location;
using AER.Enigma.Models.Business;
using Xamarin.Essentials;

[assembly: Xamarin.Forms.Dependency(typeof(LocationServiceImplementation))]
namespace AER.Enigma.UI.UWP
{
    public class LocationServiceImplementation : ILocationServiceImplementation
    {
        public double DesiredAccuracy { get; set; }
        public bool IsGeolocationAvailable => true;
        public bool IsGeolocationEnabled => true;

        public async Task<Position> GetPositionAsync(TimeSpan? timeout = null, CancellationToken? token = null)
        {
            try
            {
                GeolocationAccuracy accuracy = this.GetAccuracy();
                var request = timeout.HasValue ? new GeolocationRequest(accuracy, timeout.Value) : new GeolocationRequest(accuracy);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}");
                    return new Position(location.Latitude, location.Longitude);
                }

                return null;
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }

            return null;
        }

        private GeolocationAccuracy GetAccuracy()
        {
            if (this.DesiredAccuracy >= 1000)
            {
                return GeolocationAccuracy.Lowest;
            }

            if (this.DesiredAccuracy >= 300 && this.DesiredAccuracy < 1000)
            {
                return GeolocationAccuracy.Low;
            }

            if (this.DesiredAccuracy >= 30 && this.DesiredAccuracy < 300)
            {
                return GeolocationAccuracy.Medium;
            }

            return GeolocationAccuracy.Best;
        }

    }
}
