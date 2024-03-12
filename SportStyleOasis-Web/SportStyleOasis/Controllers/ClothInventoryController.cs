namespace SportStyleOasis.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SportStyleOasis.Services.Interfces;
    using SportStyleOasis.Web.ViewModels.ClothInventory;
    using static SportStyleOasis.Common.GeneralApplicationConstants;
    using static SportStyleOasis.Common.NotificationMessagesConstant;

    [Authorize(Roles = AdminRoleName)]
    public class ClothInventoryController : Controller
    {
        private readonly IClothInventoryService clothInventoryService;

        public ClothInventoryController(IClothInventoryService clothInventoryService)
        {
            this.clothInventoryService = clothInventoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await clothInventoryService.GetClothInventoryAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditClothInventoryViewModel model)
        {
            try
            {
                await clothInventoryService.UpdateClothInventoryAsync(model);

                TempData[SuccessMessage] = "Successfully edit cloth inventory !";
                return RedirectToAction("ViewCloth", "Clothes", new { id = model.Id });
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
