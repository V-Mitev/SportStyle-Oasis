namespace SportStyleOasis.Services.Interfces
{
    using SportStyleOasis.Web.ViewModels.ProteinPowder;

    public interface IProteinPowderService
    {
        public Task<IEnumerable<AllProteinPowderViewModel>> AllAsync();

        public Task AddAsync(AddProteinPowderViewModel model);

        public Task DeleteProteinPowder(int id);

        public Task EditProteinPowder(int id, AddProteinPowderViewModel model);

        public Task<ProteinPowderViewModel> FindProteinPowder(int id);

        public Task<AddProteinPowderViewModel> FindProteinPowderForEdit(int id);

        public Task<bool> DoesТheProteinAlreadyExist(string porteinPowderName);

        public Task<int?> FindProteinPowderToReturnId(string porteinPowderName);

        public Task<string> GetProteinPowderName(int proteinPowderId);
    }
}
