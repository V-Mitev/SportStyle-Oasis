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
        private readonly IClothInventoryService clothInventoryService;

        public ShoppingCartController(
            IShoppingCartService shoppingCartService,
            IClothesService clothesService,
            IProteinPowderService proteinPowderService,
            IClothInventoryService clothInventoryService)
        {
            this.shoppingCartService = shoppingCartService;
            this.clothesService = clothesService;
            this.proteinPowderService = proteinPowderService;
            this.clothInventoryService = clothInventoryService;
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
                var clothName = await clothesService.GetClotheName(clothId);

                var result = await shoppingCartService.AddToShoppingCartClothe(userId, clothId, size, quantity);

                if (result == false)
                {
                    TempData[WarningMessage] =
                        $"Please add less or we don't have enough quantity of this {clothName}.";

                    return Ok();
                }

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

        //[HttpGet]
        //public async Task<IActionResult> FinishOrder(int shoppingCartId)
        //{
        //    var model = await shoppingCartService.FindShoppingCartAsync(shoppingCartId);

        //    return View(model);
        //}

        [HttpPost]
        public async Task<IActionResult> FinishOrder(int shoppingCartId)
        {
            try
            {
                var isOrderCompleted = await shoppingCartService.FinishOrder(shoppingCartId);

                if (isOrderCompleted)
                {
                    TempData[SuccessMessage] = "Order successfully completed.";

                    return RedirectToAction("Index", "Home");
                }

                return GeneralError();
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateClothInventory(int clothInventoryId, int orderedQuantity)
        {
            if (clothInventoryId == 0 || orderedQuantity == 0)
            {
                return GeneralError();
            }

            try
            {
                await clothInventoryService
                    .UpdateClothInventoryByShoppingCartAsync(clothInventoryId, orderedQuantity);

                return Ok();
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProteinPowderInventory(int proteinOrderedQuantityId, int orderedQuantity)
        {
            if (proteinOrderedQuantityId == 0 || orderedQuantity == 0)
            {
                return GeneralError();
            }

            try
            {
                await clothInventoryService
                    .UpdateProteinPowderInventoryByShoppingCartAsync(proteinOrderedQuantityId, orderedQuantity);

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
