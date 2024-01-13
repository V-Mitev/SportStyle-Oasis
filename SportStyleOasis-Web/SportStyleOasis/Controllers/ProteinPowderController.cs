namespace SportStyleOasis.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SportStyleOasis.Services.Interfces;
    using SportStyleOasis.Web.Infrastructure.Extensions;
    using SportStyleOasis.Web.ViewModels.ProteinPowder;
    using static SportStyleOasis.Common.NotificationMessagesConstant;

    public class ProteinPowderController : Controller
    {
        private readonly IProteinPowderService proteinPowderService;

        public ProteinPowderController(IProteinPowderService proteinPowderService)
        {
            this.proteinPowderService = proteinPowderService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var proteinPowders = await proteinPowderService.AllAsync();

            return View(proteinPowders);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new AddProteinPowderViewModel();
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProteinPowderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                HttpContext.Session.SetObject<AddProteinPowderViewModel>("ProteinPowder", model);

                await proteinPowderService.AddAsync(model);

                return RedirectToAction("Add", "Flavor");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> ViewProteinPowder(int id)
        {
            try
            {
                var model = await proteinPowderService.FindProteinPowder(id);

                return View(model);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await proteinPowderService.DeleteProteinPowder(id);

                TempData[SuccessMessage] = $"Successfully delete protein powder with id: {id}!";

                return RedirectToAction("All");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await proteinPowderService.FindProteinPowderForEdit(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AddProteinPowderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                await proteinPowderService.EditProteinPowder(id, model);

                TempData[SuccessMessage] = $"Successfully edit protein powder {model.Name}!";

                return RedirectToAction("All");
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
