namespace SportStyleOasis.Services.Interfces
{
    using SportStyleOasis.Web.ViewModels.ProteinPowder;

    public interface IProteinPowderService
    {
        public Task<IEnumerable<AllProteinPowderViewModel>> AllAsync();

        public Task AddAsync(AddProteinPowderViewModel model);
    }
}
