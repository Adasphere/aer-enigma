namespace AER.Enigma.UI.Pages
{
    using AER.Enigma.ViewModels;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WelcomePage : ContentPage
	{
        public SearchViewModel ViewModel
        {
            get
            {
                return (SearchViewModel)BindingContext;
            }
        }

        public WelcomePage()
        {
            InitializeComponent();

            BindingContext = ((ViewModelLocator)Application.Current.Resources["Locator"]).Search;

            this.results.ItemTapped += (s, e) =>
            {
                ViewModel.SearchCommand.Execute(e.Item);
            };

        }
    }
}