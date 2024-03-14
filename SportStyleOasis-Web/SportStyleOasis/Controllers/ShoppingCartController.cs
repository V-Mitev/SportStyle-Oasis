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
        private readonly IClothesService clothesService;
        private readonly IProteinPowderService proteinPowderService;

        public ShoppingCartController(
            IShoppingCartService shoppingCartService, 
            IClothesService clothesService,
            IProteinPowderService proteinPowderService)
        {
            this.shoppingCartService = shoppingCartService;
            this.clothesService = clothesService;
            this.proteinPowderService = proteinPowderService;
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

                var clothName = await clothesService.GetClotheName(clothId);

                TempData[SuccessMessage] =
                $"Successfully added {clothName} to the shopping cart !";

                return Ok();
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProteinToCart(int proteinId, string flavor, int quantity)
        {
            string userId = User.GetId();

            try
            {
                await shoppingCartService.AddToShoppingCartProtein(userId, proteinId, flavor, quantity);

                var proteinPowderName = await proteinPowderService.GetProteinPowderName(proteinId);

                TempData[SuccessMessage] =
                $"Successfully added {proteinPowderName} to the shopping cart !";

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
                var clothName = await clothesService.GetClotheName(clothId);

                await shoppingCartService.RemoveClothFromCart(shoppingCartId, clothId, size);

                TempData[SuccessMessage] = $"Successfully removed {clothName} from the cart.";

                return Ok();
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveProteinFromCart(int shoppingCartId, int proteinId, string flavor)
        {
            try
            {
                var proteinPowderName = await proteinPowderService.GetProteinPowderName(proteinId);

                await shoppingCartService.RemoveProteinFromCart(shoppingCartId, proteinId, flavor);

                TempData[SuccessMessage] = $"Successfully remove {proteinPowderName} from the cart.";

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
