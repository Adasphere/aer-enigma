using System;
using System.Collections.Generic;
using System.Text;

namespace AER.Enigma.Services.Files
{
    public interface ILocalFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}
