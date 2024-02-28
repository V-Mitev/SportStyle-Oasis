namespace SportStyleOasis.Services.Interfces
{
    using SportStyleOasis.Web.ViewModels.ShoppingCart;

    public interface IShoppingCartService
    {
        Task<ShoppingCartViewModel> FindShoppingCartByUserIdAsync(string userId);

        Task<int> GetShoppingCartItemsAsync(int cartId);
    }
}
