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

        public ShoppingCartService(
            SportStyleOasisDbContext dbContext,
            IClothInventoryService clothInventoryService,
            IFlavorService flavorService,
            IClothOrderQuantityService clothOrderQuantityService)
        {
            this.dbContext = dbContext;
            this.clothInventoryService = clothInventoryService;
            this.flavorService = flavorService;
            this.clothOrderQuantityService = clothOrderQuantityService;
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

        public async Task AddToShoppingCartProtein(string userId, int proteinId, string proteinFlavor)
        {
            var protein = await flavorService.GetProteinFlavorAsync(proteinId, proteinFlavor);

            var shoppingCart = await dbContext.ShoppingCarts
                .Where(sc => sc.UserId.ToString() == userId)
                .FirstOrDefaultAsync();

            if (shoppingCart == null)
            {
                throw new InvalidOperationException("Shopping cart was not found for the user.");
            }

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
                        Color = ci.Clothe.Color,
                        Image = ci.Clothe.Image,
                        Name = ci.Clothe.Name,
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
                        ProteinPowderBrand = pf.Protein.ProteinPowderBrands
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

            var clotInventory = await dbContext.ClotheInventories
            .FirstOrDefaultAsync(a =>
                a.Clothe.Id == clothId &&
                a.ClothesSize == clothSizeEnum &&
                a.ShoppingCarts.Contains(shoppingCart));


            if (clotInventory == null)
            {
                throw new InvalidOperationException("Shopping cart clote was not found in this shopping cart.");
            }

            shoppingCart.ClotheInventories.Remove(clotInventory);

            await dbContext.SaveChangesAsync();
        }
    }
}
