namespace SportStyleOasis.Services
{
    using Microsoft.EntityFrameworkCore;
    using SportStyleOasis.Data;
    using SportStyleOasis.Data.Models.Enums;
    using SportStyleOasis.Services.Interfces;
    using SportStyleOasis.Web.ViewModels.Clothes;
    using SportStyleOasis.Web.ViewModels.ProteinPowder;
    using SportStyleOasis.Web.ViewModels.ShoppingCart;
    using System.Threading.Tasks;

    public class ShoppingCartService : IShoppingCartService
    {
        private readonly SportStyleOasisDbContext dbContext;
        private readonly IClothInventoryService clothInventoryService;
        private readonly IFlavorService flavorService;
        private readonly IClothOrderQuantityService clothOrderQuantityService;
        private readonly IProteinOrderQuantityService proteinOrderQuantityService;

        public ShoppingCartService(
            SportStyleOasisDbContext dbContext,
            IClothInventoryService clothInventoryService,
            IFlavorService flavorService,
            IClothOrderQuantityService clothOrderQuantityService,
            IProteinOrderQuantityService proteinOrderQuantityService)
        {
            this.dbContext = dbContext;
            this.clothInventoryService = clothInventoryService;
            this.flavorService = flavorService;
            this.clothOrderQuantityService = clothOrderQuantityService;
            this.proteinOrderQuantityService = proteinOrderQuantityService;
        }

        public async Task AddToShoppingCartClothe(string userId, int clothId, string size, int quantity)
        {
            var cloth = await clothInventoryService.GetClothesWithFilteredInventory(clothId, size, quantity);

            var shoppingCart = await dbContext.ShoppingCarts
                .Where(sc => sc.UserId.ToString() == userId)
                .FirstOrDefaultAsync();

            if (shoppingCart == null)
            {
                throw new InvalidOperationException("Shopping cart was not found for the user.");
            }

            cloth.ClotheOrderQuantity = await clothOrderQuantityService.AddClothOrderQuantityAsync(quantity);

            shoppingCart.ClotheInventories.Add(cloth);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddToShoppingCartProtein(string userId, int proteinId, string proteinFlavor, int quantity)
        {
            var protein = await flavorService.GetProteinFlavorAsync(proteinId, proteinFlavor);

            var shoppingCart = await dbContext.ShoppingCarts
                .Where(sc => sc.UserId.ToString() == userId)
                .FirstOrDefaultAsync();

            if (shoppingCart == null)
            {
                throw new InvalidOperationException("Shopping cart was not found for the user.");
            }

            protein.ProteinOrderQuantity = await proteinOrderQuantityService.AddProteinOrderQuantityAsync(quantity);

            shoppingCart.ProteinFlavors.Add(protein);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ShoppingCartViewModel> FindShoppingCartAsync(int cartId)
        {
            var shoppingCart = await dbContext.ShoppingCarts
                .Include(sc => sc.ClotheInventories)
                .Include(sc => sc.ProteinFlavors)
                .Where(sc => sc.Id == cartId)
                .Select(sc => new ShoppingCartViewModel()
                {
                    Id = sc.Id,
                    Clothes = sc.ClotheInventories
                    .Select(ci => new ClothForShoppingCartViewModel()
                    {
                        Id = ci.Clothe.Id,
                        Name = ci.Clothe.Name,
                        Color = ci.Clothe.Color,
                        Image = ci.Clothe.Image,
                        Price = ci.Clothe.Price,
                        Size = ci.ClothesSize.ToString()!,
                        OrderedQuantity = ci.ClotheOrderQuantity!.Quantity
                    }).ToList(),
                    ProteinPowders = sc.ProteinFlavors
                    .Select(pf => new ProteinPowderForShoppingCartViewModel()
                    {
                        Id = pf.ProteinId,
                        Name = pf.Protein.Name,
                        Image = pf.Protein.Image,
                        Price = pf.Protein.Price,
                        Weight = pf.Protein.Weight,
                        FlavorName = pf.FlavorName,
                        TypeOfProtein = pf.Protein.TypeOfProtein,
                        ProteinPowderBrand = pf.Protein.ProteinPowderBrands,
                        OrderedQuantity = pf.ProteinOrderQuantity!.Quantity
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (shoppingCart == null)
            {
                throw new InvalidOperationException("Shopping cart was not found for the user.");
            }

            return shoppingCart;
        }

        public async Task<int> GetShoppingCartIdAsync(string userId)
        {
            var shoppingCart = await dbContext.ShoppingCarts
                .Where(sc => sc.UserId.ToString() == userId)
                .FirstOrDefaultAsync();

            if (shoppingCart == null)
            {
                throw new InvalidOperationException("Shopping cart was not found for the user.");
            }

            return shoppingCart.Id;
        }

        public async Task<int> GetShoppingCartItemsAsync(int cartId)
        {
            var shoppingCart = await dbContext.ShoppingCarts
                .Include(sc => sc.ClotheInventories)
                .Include(sc => sc.ProteinFlavors)
                .FirstOrDefaultAsync(sc => sc.Id == cartId);

            if (shoppingCart == null)
            {
                throw new InvalidOperationException("Shopping cart was not found for the user.");
            }

            return shoppingCart.ProteinFlavors.Count + shoppingCart.ClotheInventories.Count;
        }

        public async Task RemoveClothFromCart(int shoppingCartId, int clothId, string size)
        {
            var shoppingCart = await dbContext.ShoppingCarts
                .Include(sc => sc.ClotheInventories)
                .FirstOrDefaultAsync(sc => sc.Id == shoppingCartId);

            if (shoppingCart == null)
            {
                throw new InvalidOperationException("Shopping cart was not found for the user.");
            }

            var clothSize = Enum.TryParse(size, out ClothesSize clothSizeEnum);

            var clothInventory = await dbContext.ClotheInventories
                .Include(ci => ci.ClotheOrderQuantity)
                .FirstOrDefaultAsync(a =>
                    a.Clothe.Id == clothId &&
                    a.ClothesSize == clothSizeEnum &&
                    a.ShoppingCarts.Contains(shoppingCart));


            if (clothInventory == null)
            {
                throw new InvalidOperationException("Shopping cart clothe was not found in this shopping cart.");
            }

            shoppingCart.ClotheInventories.Remove(clothInventory);
            dbContext.ClotheOrderQuantities.Remove(clothInventory.ClotheOrderQuantity!);

            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveProteinFromCart(int shoppingCartId, int proteinId, string flavor)
        {
            var shoppingCart = await dbContext.ShoppingCarts
               .Include(sc => sc.ProteinFlavors)
               .FirstOrDefaultAsync(sc => sc.Id == shoppingCartId);

            if (shoppingCart == null)
            {
                throw new InvalidOperationException("Shopping cart was not found for the user.");
            }

            var proteinFlavor = await dbContext.ProteinFlavor
                .Include(pf => pf.ProteinOrderQuantity)
                .FirstOrDefaultAsync(pf =>
                pf.ProteinId == proteinId &&
                pf.FlavorName == flavor &&
                pf.ShoppingCarts.Contains(shoppingCart));

            if (proteinFlavor == null)
            {
                throw new InvalidOperationException("This protein was not found in the shopping cart.");
            }

            shoppingCart.ProteinFlavors.Remove(proteinFlavor);
            dbContext.ProteinOrderQuantities.Remove(proteinFlavor.ProteinOrderQuantity!);

            await dbContext.SaveChangesAsync();
        }
    }
}
