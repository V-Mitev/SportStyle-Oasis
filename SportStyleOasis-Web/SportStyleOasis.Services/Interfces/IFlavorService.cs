namespace SportStyleOasis.Services.Interfces
{
    using SportStyleOasis.Web.ViewModels.ProteinFlavor;

    public interface IFlavorService
    {
        public Task AddFlavorAsync(ProteinFlavorViewModel flavor, int id);

        public Task<bool> IsFlavorAlreadyAdded(int roteinPowderId, string flavorName);
    }
}
