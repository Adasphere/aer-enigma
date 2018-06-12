using System;
using System.Collections.Generic;
using System.Text;

namespace AER.Enigma.UI.Services
{
    using System.Threading.Tasks;

    using Acr.UserDialogs;

    using AER.Enigma.UI.ViewModels.Services;

    public class DialogService : IDialogService
    {
        public Task ShowAlertAsync(string message, string title, string buttonLabel)
        {
            return UserDialogs.Instance.AlertAsync(message, title, buttonLabel);
        }
    }
}
