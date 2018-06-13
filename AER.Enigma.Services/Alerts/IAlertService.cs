using System;
using System.Collections.Generic;
using System.Text;

namespace AER.Enigma.Services.Alerts
{
    using System.Threading.Tasks;

    using AER.Enigma.Models.Business;

    public interface IAlertService
    {
        Task<Alert> GetAlertAsync(Models.Business.Location location);
    }
}
