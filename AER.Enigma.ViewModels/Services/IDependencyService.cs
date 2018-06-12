namespace AER.Enigma.UI.ViewModels.Services
{
    public interface IDependencyService
    {
        T Get<T>() where T : class;
    }
}
