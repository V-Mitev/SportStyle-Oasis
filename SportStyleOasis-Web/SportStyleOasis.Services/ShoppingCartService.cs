namespace SportStyleOasis.Services
{
    using Microsoft.EntityFrameworkCore;
    using SportStyleOasis.Data;
    using SportStyleOasis.Data.Models;
    using SportStyleOasis.Data.Models.Enums;
    using SportStyleOasis.Services.Interfces;
    using SportStyleOasis.Web.ViewModels.Clothes;
    using SportStyleOasis.Web.ViewModels.ProteinPowder;
    using SportStyleOasis.Web.ViewModels.ShoppingCart;
    using System.Threading.Tasks;

    public class ShoppingCartService : IShoppingCartService
    {
        private readonly SportStyleOasisDbContext dbContext;

        public ShoppingCartService(SportStyleOasisDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ShoppingCartViewModel> FindShoppingCartAsync(int cartId)
        {
            var shoppingCart = await dbContext.ShoppingCarts
                .Include(sc => sc.Clothes)
                .ThenInclude(c => c.ClotheInventories)
                .Include(sc => sc.ProteinPowders)
                .Where(sc => sc.Id == cartId)
                .Select(sc => new ShoppingCartViewModel()
                {
                    Id = sc.Id,
                    Clothes = sc.Clothes
                        .Select(c => new ClothForShoppingCartViewModel()
                        {
                            Id = c.Id,
                            Color = c.Color,
                            Name = c.Name,
                            Image = c.Image,
                            Price = c.Price,
                            Size = (ClothesSize)c.ClotheInventories
                                    .Where(ci => ci.ClothId == c.Id)
                                    .Select(ci => ci.ClothesSize)
                                    .FirstOrDefault()!
                        }).ToList(),
                    ProteinPowders = sc.ProteinPowders
                        .Select(pp => new ProteinForShoppingCartViewModel()
                        {
                            Id = pp.Id,
                            Name = pp.Name,
                            Image = pp.Image,
                            Price = pp.Price,
                            Weight = pp.Weight
                        }).ToList(),
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
                .FirstOrDefaultAsync(sc => sc.Id == cartId) ?? throw new InvalidOperationException("Shopping cart was not found for the user.");

            return shoppingCart.ProteinPowders.Count + shoppingCart.Clothes.Count;
        }
    }
}
