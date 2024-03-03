namespace SportStyleOasis.Services.Interfces
{
    using SportStyleOasis.Data.Models;
    using SportStyleOasis.Web.ViewModels.Clothes;

    public interface IClothesService
    {
        public Task<IEnumerable<AllClothesViewModel>> AllAsync();

        public Task AddClotheAsync(AddClotheViewModel model);

        public Task DeleteGarmentAsync(int id);

        public Task UpdateGarmentAsync(int id, UpdateClothViewModel model);

        public Task<UpdateClothViewModel> FindGarmentToUpdateAsync(int id);

        public Task<ClothViewModel> ViewClothAsync(int id);

        public Task<IEnumerable<AllClothesViewModel>> ReturnTypeOfClothesAsync(string gender, string clothes);

        public Task<Clothes> GetClothesWithFilteredInventory(int clothId, string clothSize);
    }
}
