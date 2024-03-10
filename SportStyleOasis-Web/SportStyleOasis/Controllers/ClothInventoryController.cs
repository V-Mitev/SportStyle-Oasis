namespace SportStyleOasis.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SportStyleOasis.Services.Interfces;
    using SportStyleOasis.Web.ViewModels.ClothInventory;
    using static SportStyleOasis.Common.GeneralApplicationConstants;

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
            return View();
        }
    }
}
