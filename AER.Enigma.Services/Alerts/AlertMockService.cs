using System;
using System.Collections.Generic;
using System.Text;

namespace AER.Enigma.Services.Alerts
{
    using System.Threading.Tasks;

    using AER.Enigma.Models.Business;

    public class AlertMockService : IAlertService
    {
        public async Task<Alert> GetAlertAsync(Location location)
        {
            Task<Alert> task = Task<Alert>.Factory.StartNew(
                () =>
                    {
                        return new Alert
                                   {
                                       Length = TimeSpan.FromHours(3),
                                       Level = AlertLevel.Danger,
                                       Message = "Severe hurricane barrelling down on you.",
                                       Title = "Hurricane Danger!"
                                   };
                    });

            return await task;
        }
    }
}
