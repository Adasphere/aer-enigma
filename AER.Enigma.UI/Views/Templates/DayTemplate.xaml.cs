// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DayTemplate.xaml.cs" company="Adasphere">
//   2018
// </copyright>
// <summary>
//   Defines the DayTemplate type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AER.Enigma.UI.Views.Templates
{
    using System;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// The day template.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DayTemplate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DayTemplate"/> class.
        /// </summary>
        public DayTemplate()
        {
            this.InitializeComponent();

            // Creating TapGestureRecognizers  
            var tapPreviousImage = new TapGestureRecognizer();
            var tapNextImage = new TapGestureRecognizer();

            // Binding events  
            tapPreviousImage.Tapped += TapPreviousImageTapped;
            tapNextImage.Tapped += TapNextImageTapped;

            // Associating tap events to the image buttons  
            this.PreviousDayImage.GestureRecognizers.Add(tapPreviousImage);
            this.NextDayImage.GestureRecognizers.Add(tapNextImage);

            void TapPreviousImageTapped(object sender, EventArgs e)
            {
                // handle the tap  
                var action = App.Current.MainPage.DisplayActionSheet("Previous day", "Cancel", null, "Modify context to display the previous day’s data");

                // DisplayAlert("Alert", "This is an image button", "OK");
                // Display alert has to be on a page and not for a template.
            }

            void TapNextImageTapped(object sender, EventArgs e)
            {
                // handle the tap  
                var action = App.Current.MainPage.DisplayActionSheet("Next day", "Cancel", null, "Modify context to display the next day’s data");

                // DisplayAlert("Alert", "This is an image button", "OK");
                // Display alert has to be on a page and not for a template.
            }
        }
    }
}