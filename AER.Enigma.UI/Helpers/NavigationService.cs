namespace AER.Enigma.UI.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using GalaSoft.MvvmLight.Views;

    using Xamarin.Forms;

    public class NavigationService : INavigationService
    {
        private readonly Dictionary<string, Type> _pagesByKey = new Dictionary<string, Type>();
        private NavigationPage _navigation;

        public string CurrentPageKey
        {
            get
            {
                lock (this._pagesByKey)
                {
                    if (this._navigation.CurrentPage == null)
                    {
                        return null;
                    }

                    var pageType = this._navigation.CurrentPage.GetType();

                    return this._pagesByKey.ContainsValue(pageType)
                        ? this._pagesByKey.First(p => p.Value == pageType).Key
                        : null;
                }
            }
        }

        public void GoBack()
        {
            this._navigation.PopAsync();
        }

        public void NavigateTo(string pageKey)
        {
            this.NavigateTo(pageKey, null);
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            lock (this._pagesByKey)
            {
                if (this._pagesByKey.ContainsKey(pageKey))
                {
                    var type = this._pagesByKey[pageKey];
                    ConstructorInfo constructor = null;
                    object[] parameters = null;

                    if (parameter == null)
                    {
                        constructor = type.GetTypeInfo()
                            .DeclaredConstructors
                            .FirstOrDefault(c => !c.GetParameters().Any());

                        parameters = new object[]
                        {
                        };
                    }
                    else
                    {
                        constructor = type.GetTypeInfo()
                            .DeclaredConstructors
                            .FirstOrDefault(
                                c =>
                                {
                                    var p = c.GetParameters();
                                    return p.Count() == 1
                                           && p[0].ParameterType == parameter.GetType();
                                });

                        parameters = new[]
                        {
                            parameter
                        };
                    }

                    if (constructor == null)
                    {
                        throw new InvalidOperationException(
                            "No suitable constructor found for page " + pageKey);
                    }

                    var page = constructor.Invoke(parameters) as Page;
                    this._navigation.PushAsync(page);
                }
                else
                {
                    throw new ArgumentException(
                        string.Format(
                            "No such page: {0}. Did you forget to call NavigationService.Configure?",
                            pageKey),
                        "pageKey");
                }
            }
        }

        public void Configure(string pageKey, Type pageType)
        {
            lock (this._pagesByKey)
            {
                if (this._pagesByKey.ContainsKey(pageKey))
                {
                    this._pagesByKey[pageKey] = pageType;
                }
                else
                {
                    this._pagesByKey.Add(pageKey, pageType);
                }
            }
        }

        public void Initialize(NavigationPage navigation)
        {
            this._navigation = navigation;
        }
    }
}