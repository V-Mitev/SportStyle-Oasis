namespace SportStyleOasis.Services
{
    using Microsoft.EntityFrameworkCore;
    using SportStyleOasis.Data;
    using SportStyleOasis.Services.Interfces;
    using SportStyleOasis.Web.ViewModels.ShoppingCart;
    using System.Threading.Tasks;

    public class ShoppingCartService : IShoppingCartService
    {
        private readonly SportStyleOasisDbContext dbContext;

        public ShoppingCartService(SportStyleOasisDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ShoppingCartViewModel> FindShoppingCartByUserIdAsync(string userId)
        {
            var a = await dbContext.ShoppingCarts
                .Where(sc => sc.UserId.ToString() == userId)
                .Select(sc => new ShoppingCartViewModel()
                {
                    Id = sc.Id,
                })
                .FirstOrDefaultAsync() ?? throw new InvalidOperationException("Shopping cart was not found for the user.");

            return a;
        }

        public async Task<int> GetShoppingCartItemsAsync(int cartId)
        {
            var shoppingCart = await dbContext.ShoppingCarts
                .FirstOrDefaultAsync(sc => sc.Id == cartId) ?? throw new InvalidOperationException("Shopping cart was not found for the user.");

            return shoppingCart.ProteinPowders.Count + shoppingCart.Clothes.Count;
        }
    }
}
