namespace SportStyleOasis.Services.Interfces
{
    using SportStyleOasis.Web.ViewModels.ProteinPowder;

    public interface IProteinPowderService
    {
        public Task<IEnumerable<AllProteinPowderViewModel>> AllAsync();

        public Task AddAsync(AddProteinPowderViewModel model);

        public Task<ProteinPowderViewModel> ViewProteinPowder(int id);

        public Task DeleteProteinPowder(int id);
    }
}
