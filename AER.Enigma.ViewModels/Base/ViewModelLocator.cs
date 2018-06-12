namespace AER.Enigma.UI.ViewModels.Base
{
    using System;
    using System.Globalization;
    using System.Reflection;

    using AER.Enigma.Services;
    using AER.Enigma.Services.Alerts;
    using AER.Enigma.Services.Location;
    using AER.Enigma.Services.Weather;
    using AER.Enigma.TinyIoC;

    using Xamarin.Forms;

    public static class ViewModelLocator
    {
        private static TinyIoCContainer container;

        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(ViewModelLocator.AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(ViewModelLocator.AutoWireViewModelProperty, value);
        }

        public static bool UseMockService { get; set; }

        static ViewModelLocator()
        {
            container = new TinyIoCContainer();

            // View models - by default, TinyIoC will register concrete classes as multi-instance.
            container.Register<LocationSearchViewModel>();
            container.Register<WeatherViewModel>();
            container.Register<AlertViewModel>();

            // Services - by default, TinyIoC will register interface registrations as singletons.
            container.Register<IWeatherService, WeatherService>();
            container.Register<ILocationSearchService, LocationSearchMockService>();
            //container.Register<IOpenUrlService, OpenUrlService>();
            //container.Register<IIdentityService, IdentityService>();
            container.Register<IRequestProvider, RequestProvider>();
            //container.Register<IDependencyService, Services.Dependency.DependencyService>();
            //container.Register<ISettingsService, SettingsService>();
            //container.Register<IFixUriService, FixUriService>();
            container.Register<ILocationService, LocationService>();
            //container.Register<ICatalogService, CatalogMockService>();
            //container.Register<IBasketService, BasketMockService>();
            //container.Register<IOrderService, OrderMockService>();
            //container.Register<IUserService, UserMockService>();
            //container.Register<ICampaignService, CampaignMockService>();
            container.Register<IAlertService, AlertMockService>();
        }

        public static void RegisterUIServices<RegisterType, RegisterImplementation>()
            where RegisterType : class
            where RegisterImplementation : class, RegisterType
        {
            container.Register<RegisterType, RegisterImplementation>();
        }

        public static void UpdateDependencies(bool useMockServices)
        {
            // Change injected dependencies
            if (useMockServices)
            {
                container.Register<ILocationSearchService, LocationSearchMockService>();
                container.Register<IWeatherService, WeatherMockService>();
                container.Register<IAlertService, AlertMockService>();
                //container.Register<ICatalogService, CatalogMockService>();
                //container.Register<IBasketService, BasketMockService>();
                //container.Register<IOrderService, OrderMockService>();
                //container.Register<IUserService, UserMockService>();
                //container.Register<ICampaignService, CampaignMockService>();

                UseMockService = true;
            }
            else
            {
                container.Register<ILocationSearchService, LocationSearchService>();
                container.Register<IWeatherService, WeatherService>();
                //container.Register<ICatalogService, CatalogService>();
                //container.Register<IBasketService, BasketService>();
                //container.Register<IOrderService, OrderService>();
                //container.Register<IUserService, UserService>();
                //container.Register<ICampaignService, CampaignService>();
                container.Register<IAlertService, AlertMockService>();

                UseMockService = false;
            }
        }

        public static void RegisterSingleton<TInterface, T>() where TInterface : class where T : class, TInterface
        {
            container.Register<TInterface, T>().AsSingleton();
        }

        public static T Resolve<T>() where T : class
        {
            return container.Resolve<T>();
        }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;
            if (view == null)
            {
                return;
            }

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            //var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelAssemblyName = typeof(ViewModelLocator).Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewModelAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
            {
                return;
            }
            var viewModel = container.Resolve(viewModelType);
            view.BindingContext = viewModel;
        }
    }
}