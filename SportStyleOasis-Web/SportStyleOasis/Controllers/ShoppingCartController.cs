namespace SportStyleOasis.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SportStyleOasis.Services.Interfces;
    using SportStyleOasis.Web.Infrastructure.Extensions;
    using static SportStyleOasis.Common.NotificationMessagesConstant;

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
            try
            {
                var shoppingCart = await shoppingCartService.FindShoppingCartAsync(cartId);

                return View(shoppingCart);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddClotheToCart(int clothId, string size, int quantity)
        {
            string userId = User.GetId();

            try
            {
                await shoppingCartService.AddToShoppingCartClothe(userId, clothId, size, quantity);

                TempData[SuccessMessage] =
                "Successfully added clothe to the shopping cart !";

                return Ok();
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProteinToCart(int proteinId, string proteinFlavor)
        {
            string userId = User.GetId();

            try
            {
                await shoppingCartService.AddToShoppingCartProtein(userId, proteinId, proteinFlavor);

                TempData[SuccessMessage] =
                "Successfully added protein powder to the shopping cart !";

                return Ok();
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveClothFromCart(int shoppingCartId, int clothId, string size)
        {
            try
            {
                await shoppingCartService.RemoveClothFromCart(shoppingCartId, clothId, size);

                return Ok();
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        private IActionResult GeneralError()
        {
            TempData[ErrorMessage] =
                "Unexpected error occurred! Please try again later or contact administrator";

            return RedirectToAction("Index", "Home");
        }
    }
}
