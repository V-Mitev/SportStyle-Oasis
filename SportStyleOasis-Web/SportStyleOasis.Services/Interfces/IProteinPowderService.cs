namespace SportStyleOasis.Services.Interfces
{
    using SportStyleOasis.Services.Data.Models.ProteinPowder;
    using SportStyleOasis.Web.ViewModels.ProteinPowder;

    public interface IProteinPowderService
    {
        public Task<AllProteinsFilteredAndPagedServiceModel> AllAsync(AllProteinsQueryModel queryModel);

        public Task AddAsync(AddProteinPowderViewModel model);
        
        public Task DeleteProteinPowder(int id);

        public Task EditProteinPowder(int id, AddProteinPowderViewModel model);

        public Task<ProteinPowderViewModel> FindProteinPowder(int id);

        public Task<AddProteinPowderViewModel> FindProteinPowderForEdit(int id);

        public Task<bool> DoesТheProteinAlreadyExist(string porteinPowderName);

        public Task<int?> FindProteinPowderToReturnId(string porteinPowderName);

        public Task<string> GetProteinPowderName(int proteinPowderId);

        public Task<int> AllProteinsCount();
    }
}
