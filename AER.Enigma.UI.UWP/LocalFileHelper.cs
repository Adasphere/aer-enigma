using System.IO;
using Xamarin.Forms;
using Windows.Storage;
using AER.Enigma.UI.UWP;
using AER.Enigma.Services.Files;

[assembly: Dependency(typeof(LocalFileHelper))]
namespace AER.Enigma.UI.UWP
{
    public class LocalFileHelper : ILocalFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}
