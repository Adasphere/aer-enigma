namespace AER.Enigma.UI.ViewModels
{
    using System.Threading.Tasks;
    using System.Windows.Input;

    using AER.Enigma.Models.UI;
    using AER.Enigma.UI.ViewModels.Base;

    using Xamarin.Forms;

    public class MainViewModel : ViewModelBase
    {
        public ICommand SettingsCommand => new Command(async () => await this.SettingsAsync());

        public override Task InitializeAsync(object navigationData)
        {
            this.IsBusy = true;

            if (navigationData is TabParameter)
            {
                // Change selected application tab
                var tabIndex = ((TabParameter)navigationData).TabIndex;
                MessagingCenter.Send(this, MessageKeys.ChangeTab, tabIndex);
            }

            return base.InitializeAsync(navigationData);
        }

        private async Task SettingsAsync()
        {
            await this.NavigationService.NavigateToAsync<SettingsViewModel>();
        }
    }
}
