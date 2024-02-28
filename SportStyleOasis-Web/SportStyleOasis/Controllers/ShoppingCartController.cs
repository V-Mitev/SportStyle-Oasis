namespace SportStyleOasis.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SportStyleOasis.Services.Interfces;

    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            this.shoppingCartService = shoppingCartService;
        }

        [HttpGet]
        public async Task<IActionResult> ViewShoppingCart(int cartId)
        {
            var shoppingCart = await shoppingCartService.FindShoppingCartAsync(cartId);

            return View(shoppingCart);
        }
    }
}
