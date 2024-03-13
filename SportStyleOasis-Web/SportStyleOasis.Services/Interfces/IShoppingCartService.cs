namespace SportStyleOasis.Services.Interfces
{
    using SportStyleOasis.Web.ViewModels.ShoppingCart;

    public interface IShoppingCartService
    {
        Task<ShoppingCartViewModel> FindShoppingCartAsync(int cartId);

        Task<int> GetShoppingCartItemsAsync(int cartId);

        Task<int> GetShoppingCartIdAsync(string userId);

        Task AddToShoppingCartClothe(string userId, int clothId, string size, int quantity);

        Task AddToShoppingCartProtein(string userId, int proteinId, string proteinFlavor, int quantity);

        Task RemoveClothFromCart(int shoppingCartId, int clothId, string size);

        Task RemoveProteinFromCart(int shoppingCartId, int proteinId, string flavor);
    }
}
