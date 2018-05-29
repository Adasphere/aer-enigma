using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AER.Enigma.UI.Views.Templates
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WeatherTemplate : ContentView
	{
		public WeatherTemplate ()
		{
			InitializeComponent ();
		}
	}
}