namespace SportStyleOasis.Services.Interfces
{
    using SportStyleOasis.Data.Models;
    using SportStyleOasis.Web.ViewModels.ClothInventory;

    public interface IClothInventoryService
    {
        public Task<ClotheInventory> GetClothesWithFilteredInventory(int clothId, string clothSize, int quantity);

        public Task<EditClothInventoryViewModel> GetClothInventoryAsync(int clothId);

        public Task<ClotheInventory?> ReturnClothInventoryAsync(int clothId);

        public Task UpdateClothInventoryAsync(EditClothInventoryViewModel model);

        public Task UpdateClothInventoryByShoppingCartAsync(int clothInventoryId, int orderedQuantity);

        public Task UpdateProteinPowderInventoryByShoppingCartAsync(int proteinPowderInventoryId, int orderedQuantity);
    }
}
