using Xamarin.Forms;
using AER.Enigma.UI.Droid;

[assembly: Dependency(typeof(LocationServiceImplementation))]
namespace AER.Enigma.UI.Droid
{
    using AER.Enigma.Models.Business;
    using AER.Enigma.Services.Location;
    using System.Threading;
    using System.Threading.Tasks;
    using Android.App;
    using Android.Content;
    using Android.Locations;
    using System;
    using System.Linq;
    using Xamarin.Essentials;

    public class LocationServiceImplementation : ILocationServiceImplementation
    {
        public double DesiredAccuracy { get; set; }

        LocationManager _locationManager;
        public bool IsGeolocationAvailable => true;

        string[] Providers => Manager.GetProviders(enabledOnly: false).ToArray();

        string[] IgnoredProviders => new string[] { LocationManager.PassiveProvider, "local_database" };

        LocationManager Manager
        {
            get
            {
                if (_locationManager == null)
                    _locationManager = (LocationManager)Application.Context.GetSystemService(Context.LocationService);
                return _locationManager;
            }
        }


        public bool IsGeolocationEnabled
        {
            get
            {
                string[] providers = this.Providers;

                return providers.Any(p => !IgnoredProviders.Contains(p) && Manager.IsProviderEnabled(p));
            }

        }


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
                }

                return new Position(location.Latitude, location.Longitude);
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
            if (this.DesiredAccuracy >= 500)
            {
                return GeolocationAccuracy.Low;
            }

            if (this.DesiredAccuracy >= 100 && this.DesiredAccuracy < 500)
            {
                return GeolocationAccuracy.Medium;
            }

            return GeolocationAccuracy.Best;
        }
    }
}