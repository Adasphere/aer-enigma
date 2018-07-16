// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SplashView.xaml.cs" company="Adasphere">
//   2018
// </copyright>
// <summary>
//   Defines the SplashView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AER.Enigma.UI.Views
{
    using System;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// The splash view.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SplashView"/> class.
        /// </summary>
        public SplashView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Sets the enabled button state.
        /// </summary>
        /// <param name="startButtonState">
        /// The start button state.
        /// </param>
        public void SetIsEnabledButtonState(bool startButtonState)
        {
            this.startButton.IsEnabled = startButtonState;
        }

        /// <summary>
        /// The start animation button clicked.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public async void StartAnimationButtonClicked(object sender, EventArgs e)
        {
            this.SetIsEnabledButtonState(true);

            await this.Image.RotateTo(3000, 4000);
            this.Image.Rotation = 0;

            this.SetIsEnabledButtonState(false);

            // After animation it goes to the weather view.
            Application.Current.MainPage = new NavigationPage(new WeatherView()); 
        }
    }
}