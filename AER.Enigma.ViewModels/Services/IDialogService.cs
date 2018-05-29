namespace AER.Enigma.UI.ViewModels.Services
{
    using System.Threading.Tasks;

    public interface IDialogService
    {
        Task ShowAlertAsync(string message, string title, string buttonLabel);
    }
}
