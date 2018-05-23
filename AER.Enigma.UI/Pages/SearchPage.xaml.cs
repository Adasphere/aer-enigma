using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AER.Enigma.UI.Pages
{
    using AER.Enigma.ViewModels;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchPage : ContentPage
	{
	    public SearchViewModel ViewModel
	    {
	        get
	        {
	            return (SearchViewModel)BindingContext;
	        }
	    }

        public SearchPage ()
		{
			InitializeComponent ();

		    BindingContext = ((ViewModelLocator)Application.Current.Resources["Locator"]).Search;

		    this.results.ItemTapped += (s, e) =>
		        {
		            ViewModel.SearchCommand.Execute(e.Item);
		        };

        }
    }
}