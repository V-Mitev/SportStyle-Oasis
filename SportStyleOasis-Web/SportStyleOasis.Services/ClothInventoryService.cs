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
                .Include(ci => ci.ClotheOrderQuantity)
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

        public async Task<ClotheInventory?> ReturnClothInventoryAsync(int clothId)
        {
            return await dbContext.ClotheInventories
                .FirstOrDefaultAsync(c => c.ClothId == clothId) ?? null;
        }

        public async Task UpdateClothInventoryAsync(EditClothInventoryViewModel model)
        {
            var clothInventories = await dbContext.ClotheInventories
                 .Where(ci => ci.ClothId == model.Id)
                 .ToListAsync();

            foreach (var clothInventory in clothInventories)
            {
                var clothSize = clothInventory.ClothesSize.ToString()!;

                if (model.ClotheQuantityAndSize.ContainsKey(clothSize))
                {
                    var availableQuantity = model.ClotheQuantityAndSize[clothSize];

                    clothInventory.AvailableQuantity = availableQuantity;
                }
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateClothInventoryByShoppingCartAsync(int clothInventoryId, int orderedQuantity)
        {
            var clothInventory = await dbContext.ClotheInventories
                .Include(ci => ci.ClotheOrderQuantity)
                .FirstAsync(ci => ci.Id == clothInventoryId);

            clothInventory.ClotheOrderQuantity!.Quantity = orderedQuantity;
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateProteinPowderInventoryByShoppingCartAsync(int proteinPowderInventoryId, int orderedQuantity)
        {
            var proteinPowderInventory = await dbContext.ProteinOrderQuantities
                .FirstOrDefaultAsync(pf => pf.Id == proteinPowderInventoryId);

            if (proteinPowderInventory == null)
            {
                throw new InvalidOperationException();
            }

            proteinPowderInventory.Quantity = orderedQuantity;
            await dbContext.SaveChangesAsync();
        }
    }
}
