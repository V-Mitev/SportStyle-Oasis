namespace SportStyleOasis.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SportStyleOasis.Services.Interfces;
    using SportStyleOasis.Web.ViewModels.ProteinFlavor;
    using static SportStyleOasis.Common.NotificationMessagesConstant;
    using static SportStyleOasis.Common.GeneralApplicationConstants;

    public class FlavorController : Controller
    {
        private readonly IFlavorService flavorService;

        public FlavorController(IFlavorService flavorService)
        {
            this.flavorService = flavorService;
        }

        [HttpGet]
        [Authorize(Roles = AdminRoleName)]
        public IActionResult Add()
        {
            var model = new ProteinFlavorViewModel();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Add(ProteinFlavorViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var isAlreadyAddedFlavor = await flavorService.IsFlavorAlreadyAdded(id, model.FlavorName);

            if (isAlreadyAddedFlavor)
            {
                TempData[ErrorMessage] = $"This flavor: {model.FlavorName} is already added! Please try again with new flavor.";
            }

            try
            {
                await flavorService.AddFlavorAsync(model, id);

                TempData[SuccessMessage] = $"Successfully added flavor {model.FlavorName} to protein powder.";

                return RedirectToAction("ViewProteinPowder", "ProteinPowder", new { id = id });
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
