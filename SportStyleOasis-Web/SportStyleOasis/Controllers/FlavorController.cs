namespace SportStyleOasis.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SportStyleOasis.Services.Interfces;
    using SportStyleOasis.Web.Infrastructure.Extensions;
    using SportStyleOasis.Web.ViewModels.ProteinFlavor;
    using SportStyleOasis.Web.ViewModels.ProteinPowder;
    using static SportStyleOasis.Common.NotificationMessagesConstant;

    public class FlavorController : Controller
    {
        private readonly IFlavorService flavorService;

        public FlavorController(IFlavorService flavorService)
        {
            this.flavorService = flavorService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new ProteinFlavorViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProteinFlavorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var proteinPowderModel = HttpContext.Session.GetObject<AddProteinPowderViewModel>("ProteinPowder");

            if (proteinPowderModel == null)
            {
                TempData[ErrorMessage] = "Please first add protein powder then and flavor!";

                return RedirectToAction("Add", "ProteinPowder");
            }

            try
            {
                await flavorService.AddFlavorAsync(model, proteinPowderModel.Name);

                return RedirectToAction("All", "ProteinPowder");
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
