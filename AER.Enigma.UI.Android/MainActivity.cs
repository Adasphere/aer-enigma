
namespace AER.Enigma.UI.Droid
{
    using System.IO;
    using AER.Enigma.UI;

    using Android.App;
    using Android.Content.PM;
    using Android.OS;

    using SQLite.Net.Platform.XamarinAndroid;

    using Environment = System.Environment;

    [Activity(Label = "AER.Enigma.UI", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            App aerapp = new App();
            aerapp.DatabaseService.DbPath = this.GetDbPath("aer-enigma.db");
            aerapp.DatabaseService.Platform = new SQLitePlatformAndroid();
            this.LoadApplication(aerapp);
        }

        private string GetDbPath(string fileName)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, fileName);
        }
    }
}

