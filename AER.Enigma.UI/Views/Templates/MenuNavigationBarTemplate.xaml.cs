﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuNavigationBarTemplate.xaml.cs" company="Adasphere">
//   2018
// </copyright>
// <summary>
//   Defines the MenuNavigationBarTemplate type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AER.Enigma.UI.Views.Templates
{
    using System;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// The menu navigation bar template.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuNavigationBarTemplate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuNavigationBarTemplate"/> class.
        /// </summary>
        public MenuNavigationBarTemplate()
        {
            this.InitializeComponent();

            // Creating TapGestureRecognizers  
            var tapImage = new TapGestureRecognizer();
            var tapNavImage = new TapGestureRecognizer();

            // Binding events  
            tapImage.Tapped += TapImageTapped;
            tapNavImage.Tapped += TapNavImageTapped;

            // Associating tap events to the image buttons  
            this.MenuImage.GestureRecognizers.Add(tapImage);
            this.NavImage.GestureRecognizers.Add(tapNavImage);

            void TapImageTapped(object sender, EventArgs e)
            {
                // handle the tap  
                var action = App.Current.MainPage.DisplayActionSheet("Menu settings", "Cancel", null, "This would open the menu settings");
               
                // DisplayAlert("Alert", "This is an image button", "OK");
                // Display alert has to be on a page and not for a template.
            }

            void TapNavImageTapped(object sender, EventArgs e)
            {
                // handle the tap  
                var action = App.Current.MainPage.DisplayActionSheet("Navigation settings", "Cancel", null, "This would open the navigation settings");

                // DisplayAlert("Alert", "This is an image button", "OK");
                // Display alert has to be on a page and not for a template.
            }
        }
    }
}