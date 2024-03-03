namespace SportStyleOasis.Services
{
    using Microsoft.EntityFrameworkCore;
    using SportStyleOasis.Data;
    using SportStyleOasis.Data.Models;
    using SportStyleOasis.Data.Models.Enums;
    using SportStyleOasis.Services.Interfces;
    using SportStyleOasis.Web.ViewModels.Clothes;
    using SportStyleOasis.Web.ViewModels.ClothInventory;

    public class ClothInventoryService : IClothInventoryService
    {
        private readonly SportStyleOasisDbContext dbContext;

        public ClothInventoryService(SportStyleOasisDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ClotheInventory> GetClothesWithFilteredInventory(int clothId, string clothSize)
        {
            if (Enum.TryParse(clothSize, out ClothesSize clothSizeEnum))
            {
                var clothInventory = await dbContext.ClotheInventories
                .Include(ci => ci.Clothe)
                .FirstOrDefaultAsync(ci => ci.ClothId == clothId && ci.ClothesSize == clothSizeEnum);

                if (clothInventory == null)
                {
                    throw new InvalidOperationException("This clothe was not found to add it in cart.");
                }

                return clothInventory;
            }
            else
            {
                throw new InvalidOperationException("This clothe size is not found to add it in the cart.");
            }
        }
    }
}
