namespace SportStyleOasis.Services.Interfces
{
    using SportStyleOasis.Web.ViewModels.ShoppingCart;

    public interface IShoppingCartService
    {
        Task<ShoppingCartViewModel> FindShoppingCartAsync(int cartId);

        Task<int> GetShoppingCartItemsAsync(int cartId);

        Task<int> GetShoppingCartIdAsync(string userId);
    }
}
