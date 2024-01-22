namespace SportStyleOasis.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SportStyleOasis.Services.Interfces;
    using SportStyleOasis.Web.ViewModels.ProteinPowder;
    using SportStyleOasis.Web.ViewModels.ProteinReview;
    using SportStyleOasis.Web.ViewModels.Review;
    using static SportStyleOasis.Common.NotificationMessagesConstant;
    using static SportStyleOasis.Common.GeneralApplicationConstants;

    [AllowAnonymous]
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
        [Authorize(Roles = AdminRoleName)]
        public IActionResult Add()
        {
            var model = new AddProteinPowderViewModel();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Add(AddProteinPowderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var isProteinExistsAlready = await proteinPowderService.DoesТheProteinAlreadyExist(model.Name);

            if (isProteinExistsAlready)
            {
                TempData[ErrorMessage] =
                    $"Error: The protein powder with the name '{model.Name}' already exists. Please choose a different name or refrain from adding it.";

                return View(model);
            }

            try
            {
                await proteinPowderService.AddAsync(model);

                TempData[SuccessMessage] = $"Successfully created a protein powder {model.Name}.";

                TempData[WarningMessage] = 
                    "If you don't add flavor within two minutes, the protein entry will be deleted upon refreshing the page!";

                var proteinPowderId = await proteinPowderService.FindProteinPowderToReturnId(model.Name);

                return RedirectToAction("ViewProteinPowder", "ProteinPowder", new { id = proteinPowderId });
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

                var reviewModel = new ReviewViewModel();

                var viewModel = new ProteinPowderReviewViewModel()
                {
                    ProteinPowder = model,
                    Review = reviewModel
                };

                return View(viewModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        [Authorize(Roles = AdminRoleName)]
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
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await proteinPowderService.FindProteinPowderForEdit(id);

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = AdminRoleName)]
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
