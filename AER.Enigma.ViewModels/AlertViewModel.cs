using System;
using System.Collections.Generic;
using System.Text;

namespace AER.Enigma.UI.ViewModels
{
    using System.Threading.Tasks;

    using AER.Enigma.Models.Business;
    using AER.Enigma.Services.Alerts;
    using AER.Enigma.UI.ViewModels.Base;
    public class AlertViewModel : ViewModelBase<Alert>
    {
        private readonly IAlertService alertService;

        public AlertViewModel(IAlertService alertService)
        {
            this.alertService = alertService;
        }

        public override async Task InitializeAsync(object navigationData)
        {
            Location location = navigationData as Location;

            if (location != null)
            {
                 this.Model = await GetLocationAsync(location);
            }
        }

        private async Task<Alert> GetLocationAsync(Location location)
        {
            return await this.alertService.GetAlertAsync(location);
        }
    }
}
