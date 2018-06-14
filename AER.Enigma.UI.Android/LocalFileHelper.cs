using System;
using System.IO;
using Xamarin.Forms;
using AER.Enigma.UI.Droid;
using AER.Enigma.Services.Files;

[assembly: Dependency(typeof(LocalFileHelper))]
namespace AER.Enigma.UI.Droid
{
    public class LocalFileHelper : ILocalFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}