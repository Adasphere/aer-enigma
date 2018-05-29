using System;
using System.Collections.Generic;
using System.Text;

namespace AER.Enigma.UI.Services
{
    using AER.Enigma.UI.ViewModels.Services;

    public class DependencyService : IDependencyService
    {
        public T Get<T>() where T : class
        {
            return Xamarin.Forms.DependencyService.Get<T>();
        }
    }
}
