namespace AER.Enigma.UI.ViewModels.Base
{
    using System.Threading.Tasks;

    using AER.Enigma.Core;
    using AER.Enigma.UI.ViewModels.Services;

    using Xamarin.Forms;

    public abstract class ViewModelBase : ExtendedBindableObject
    {
        protected readonly IDialogService DialogService;
        protected readonly INavigationService NavigationService;

        private bool _isBusy;

        public bool IsBusy
        {
            get
            {
                return this._isBusy;
            }

            set
            {
                this._isBusy = value;
                this.RaisePropertyChanged(() => this.IsBusy);
            }
        }

        public ViewModelBase()
        {
            this.DialogService = ViewModelLocator.Resolve<IDialogService>();
            this.NavigationService = ViewModelLocator.Resolve<INavigationService>();
            GlobalSetting.Instance.BaseEndpoint = ViewModelLocator.Resolve<ISettingsService>().UrlBase;
        }

        public bool IsDesignMode => Application.Current == null;

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
    }
}
