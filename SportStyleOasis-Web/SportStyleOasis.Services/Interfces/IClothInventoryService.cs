namespace SportStyleOasis.Services.Interfces
{
    using SportStyleOasis.Data.Models;
    using SportStyleOasis.Web.ViewModels.ClothInventory;

    public interface IClothInventoryService
    {
        public Task<ClotheInventory> GetClothesWithFilteredInventory(int clothId, string clothSize, int quantity);

        public Task<EditClothInventoryViewModel> GetClothInventoryAsync(int clothId);

        public Task UpdateClothInventoryAsync(EditClothInventoryViewModel model);
    }
}
