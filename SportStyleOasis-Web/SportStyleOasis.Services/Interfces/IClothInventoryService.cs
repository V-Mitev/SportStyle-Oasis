namespace SportStyleOasis.Services.Interfces
{
    using SportStyleOasis.Data.Models;

    public interface IClothInventoryService
    {
        public Task<ClotheInventory> GetClothesWithFilteredInventory(int clothId, string clothSize, int quantity);
    }
}
