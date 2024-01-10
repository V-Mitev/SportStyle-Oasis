namespace SportStyleOasis.Services.Interfces
{
    using SportStyleOasis.Web.ViewModels.Clothes;

    public interface IClothesService
    {
        public Task<IEnumerable<AllClothesModel>> AllAsync();

        public Task AddClotheAsync(AddClotheViewModel model);

        public Task DeleteGarmentAsync(int id);

        public Task UpdateGarment(int id, UpdateGarmentViewModel model);

        public Task<UpdateGarmentViewModel> FindGarmentToUpdate(int id);
    }
}
