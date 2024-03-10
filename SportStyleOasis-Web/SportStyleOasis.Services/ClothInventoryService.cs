namespace SportStyleOasis.Services
{
    using Microsoft.EntityFrameworkCore;
    using SportStyleOasis.Data;
    using SportStyleOasis.Data.Models;
    using SportStyleOasis.Data.Models.Enums;
    using SportStyleOasis.Services.Interfces;
    using SportStyleOasis.Web.ViewModels.ClothInventory;

    public class ClothInventoryService : IClothInventoryService
    {
        private readonly SportStyleOasisDbContext dbContext;

        public ClothInventoryService(SportStyleOasisDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ClotheInventory> GetClothesWithFilteredInventory(int clothId, string clothSize, int quantity)
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

                if (clothInventory.AvailableQuantity < quantity)
                {
                    throw new InvalidOperationException("This clothe doesn't have enough available quantity.");
                }

                return clothInventory;
            }
            else
            {
                throw new InvalidOperationException("This clothe size is not found to add it in the cart.");
            }
        }

        public async Task<EditClothInventoryViewModel> GetClothInventoryAsync(int clothId)
        {
            var clothInventories = await dbContext.ClotheInventories
                .Where(ci => ci.ClothId == clothId)
                .Select(ci => new EditClothInventoryViewModel()
                {
                    Id = ci.Id,
                    ClothesSize = ci.ClothesSize,
                    AvailableQuantity = ci.AvailableQuantity
                })
                .ToListAsync();

            if (clothInventories == null)
            {
                throw new InvalidOperationException("The cloth invenory was not found");
            }

            var clothInvenotory = new EditClothInventoryViewModel()
            {
                Id = clothId
            };

            foreach (var ci in clothInventories)
            {
                clothInvenotory.ClotheQuantityAndSize.Add(ci.ClothesSize.ToString()!, ci.AvailableQuantity);
            }

            return clothInvenotory;
        }
    }
}
