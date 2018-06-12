// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchViewModel.cs" company="Adasphere">
//   2018
// </copyright>
// <summary>
//   Represents searching locations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AER.Enigma.UI.ViewModels
{
    using AER.Enigma.UI.ViewModels.Base;

    /// <summary>
    /// Represents searching locations
    /// </summary>
    public class LocationSearchViewModel : ViewModelBase
    {
        ///// <summary>
        ///// Stores the search command
        ///// </summary>
        //private ICommand searchCommand;

        ///// <summary>
        ///// Stores the selected location.
        ///// </summary>
        //private Location selectedLocation;

        //private readonly ILocationSearchService locationSearchService;

        //private readonly INavigationService navigationService;

        ///// <summary>
        ///// Initializes a new instance of the <see cref="LocationSearchViewModel"/> class.
        ///// </summary>
        ///// <param name="locationSearchService">
        ///// The location search service.
        ///// </param>
        //public LocationSearchViewModel(ILocationSearchService locationSearchService, INavigationService navigationService)
        //{
        //    this.locationSearchService = locationSearchService;

        //    this.navigationService = navigationService;

        //    this.CancellationTokenSource = new CancellationTokenSource();
        //}

        ///// <summary>
        ///// Gets the locations.
        ///// </summary>
        //public ObservableCollection<Location> Locations { get; } = new ObservableCollection<Location>();

        ///// <summary>
        ///// Gets or sets the selected location.
        ///// </summary>
        //public Location SelectedLocation
        //{
        //    get => this.selectedLocation;

        //    set
        //    {
        //        this.selectedLocation = value;
        //        if (value != null)
        //        {
        //            this.LocationSelectedCommand.Execute(value);
        //        }
        //    }
        //}

        //private bool isLoading = false;

        //public ICommand SearchCommand
        //{
        //    get
        //    {
        //        return this.searchCommand
        //               ?? (this.searchCommand = new RelayCommand<string>(
        //                       async (term) =>
        //                           {
        //                               this.Locations.Clear();

        //                               this.isLoading = true;
        //                               ((RelayCommand<string>)this.SearchCommand).RaiseCanExecuteChanged();
        //                               //RaisePropertyChanged(() => LastLoadedFormatted);

        //                               Exception error = null;

        //                               try
        //                               {
        //                                   var list = await this.locationSearchService.SearchAsync(term);

        //                                   foreach (var location in list)
        //                                   {
        //                                       this.Locations.Add(location);
        //                                       //this.Locations.Add(new LocationViewModel(this.LocationSearchService, location));
        //                                   }

        //                                   this.isLoading = false;
        //                                   //LastLoaded = DateTime.Now;
        //                               }
        //                               catch (Exception ex)
        //                               {
        //                                   error = ex;
        //                               }

        //                               if (error != null)
        //                               {
        //                                   var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
        //                                   await dialog.ShowError(error, "Error when refreshing", "OK", null);
        //                               }

        //                               this.isLoading = false;
        //                               ((RelayCommand<string>)this.SearchCommand).RaiseCanExecuteChanged();
        //                               //RaisePropertyChanged(() => LastLoadedFormatted);
        //                           },
        //                       (term) => !this.isLoading));
        //    }
        //}

        //private ICommand locationSelectedCommand;
        ///// <summary>
        ///// Gets the location selected command.
        ///// </summary>
        //protected ICommand LocationSelectedCommand
        //{
        //    get
        //    {
        //        return this.locationSelectedCommand
        //               ?? (this.locationSelectedCommand = new RelayCommand<Location>(
        //                       location =>
        //                           {
        //                               if (!this.LocationSelectedCommand.CanExecute(location))
        //                               {
        //                                   return;
        //                               }

        //                               this.navigationService.NavigateTo(ViewModelLocator.WeatherPageKey, location);
        //                           },
        //                       flower => flower != null));
        //    }
        //}

        /////// <summary>
        /////// Gets the location search service.
        /////// </summary>
        ////protected ILocationSearchService LocationSearchService
        ////{
        ////    get;
        ////}

        ///// <summary>
        ///// Gets the cancellation token source.
        ///// </summary>
        //protected CancellationTokenSource CancellationTokenSource
        //{
        //    get;
        //}

        ///// <summary>
        ///// Returns whether or not searching is available
        ///// </summary>
        ///// <param name="term">
        ///// A zip code, city, or other term used to search locations.
        ///// </param>
        ///// <returns>
        ///// The <see cref="bool"/> representing whether or not locations can be searched.
        ///// </returns>
        //private bool CanSearch(object term)
        //{
        //    return true;
        //}

        ///// <summary>
        ///// Searches locations asynchronously. Is cancellable.
        ///// </summary>
        ///// <param name="term">
        ///// A zip code, city, or other term used to search locations.
        ///// </param>
        ///// <returns>
        ///// The <see cref="Task"/> to be awaited when searching.
        ///// </returns>
        //private async Task SearchAsync(object term)
        //{
        //    CancellationToken cancellationToken = this.CancellationTokenSource.Token;

        //    try
        //    {
        //        cancellationToken.ThrowIfCancellationRequested();

        //        this.CancellationTokenSource.Cancel();

        //        IEnumerable<Location> locations = await this.locationSearchService.SearchAsync(term.ToString(), this.CancellationTokenSource.Token);

        //        foreach (Location item in locations)
        //        {
        //            this.Locations.Add(item);
        //        }

        //        cancellationToken.ThrowIfCancellationRequested();
        //    }
        //    catch (OperationCanceledException operationCanceledException)
        //    {
        //        Console.WriteLine(operationCanceledException);
        //    }
        //}
    }
}
