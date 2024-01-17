namespace SportStyleOasis.Services.Interfces
{
    using SportStyleOasis.Web.ViewModels.Clothes;

    public interface IClothesService
    {
        public Task<IEnumerable<AllClothesViewModel>> AllAsync();

        public Task AddClotheAsync(AddClotheViewModel model);

        public Task DeleteGarmentAsync(int id);

        public Task UpdateGarmentAsync(int id, UpdateGarmentViewModel model);

        public Task<UpdateGarmentViewModel> FindGarmentToUpdateAsync(int id);

        public Task<ClothViewModel> ViewClothAsync(int id);

        public Task<IEnumerable<AllClothesViewModel>> ReturnTypeOfClothesAsync(string gender, string clothes);
    }
}
