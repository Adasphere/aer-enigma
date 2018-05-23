﻿namespace AEREnigma.ViewModels
{
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    using AER.Enigma.Core.Services;
    using AER.Enigma.Core.Services.Design;

    using CommonServiceLocator;

    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Ioc;
    using GalaSoft.MvvmLight.Views;

    public class ViewModelLocator
    {
        private const bool ForceDesignData = false;

        public const string WeatherPageKey = "WeatherPage";

        static ViewModelLocator()
        {
            Debug.WriteLine("ViewModelLocator");
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (UseDesignData)
            {
                if (!SimpleIoc.Default.IsRegistered<INavigationService>())
                {
                    SimpleIoc.Default.Register<INavigationService, DesignNavigationService>();
                }

                SimpleIoc.Default.Register<ILocationSearchService, DesignLocationSearchService>();
                SimpleIoc.Default.Register<IWeatherService, DesignWeatherService>();
            }
            else
            {
                SimpleIoc.Default.Register<ILocationSearchService, MockLocationSearchService>();
                SimpleIoc.Default.Register<IWeatherService, WeatherService>();
            }

            SimpleIoc.Default.Register<SearchViewModel>();
        }

        [SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public SearchViewModel Search
        {
            get
            {
                Debug.WriteLine("Search");
                return ServiceLocator.Current.GetInstance<SearchViewModel>();
            }
        }

        private static bool UseDesignData
        {
            get
            {
                return ViewModelBase.IsInDesignModeStatic
                       || ForceDesignData;
            }
        }
    }
}