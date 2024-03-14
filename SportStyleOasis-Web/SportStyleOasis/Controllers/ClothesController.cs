namespace SportStyleOasis.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SportStyleOasis.Data.Models.Enums;
    using SportStyleOasis.Services.Interfces;
    using SportStyleOasis.Web.ViewModels.Clothes;
    using SportStyleOasis.Web.ViewModels.ClothReview;
    using SportStyleOasis.Web.ViewModels.Review;
    using static SportStyleOasis.Common.NotificationMessagesConstant;
    using static SportStyleOasis.Common.GeneralApplicationConstants;

    [Authorize]
    public class ClothesController : Controller
    {
        private readonly IClothesService clothesService;

        public ClothesController(IClothesService clothesService)
        {
            this.clothesService = clothesService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var clothes = await clothesService.AllAsync();

            return View(clothes);
        }

        [HttpGet]
        [Authorize(Roles = AdminRoleName)]
        public IActionResult Add()
        {
            AddClotheViewModel model = new AddClotheViewModel();

            foreach (var clotheSize in Enum.GetValues(typeof(ClothesSize)).Cast<ClothesSize>())
            {
                model.SizesAndQuantities[clotheSize] = 0;
            }

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Add(AddClotheViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await clothesService.AddClotheAsync(model);

                TempData[SuccessMessage] = $"Successfully added {model.Name}.";

                return RedirectToAction("All", "Clothes");
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
                var clothName = await clothesService.GetClotheName(id);

                await clothesService.DeleteGarmentAsync(id);
                TempData[SuccessMessage] = $"You have successfully delete this {clothName}.";

                return RedirectToAction("All", "Clothes");
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
            var model = await clothesService.FindGarmentToUpdateAsync(id);

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Edit(int id, UpdateClothViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await clothesService.UpdateGarmentAsync(id, model);

                TempData[SuccessMessage] = $"The clothe {model.Name} was successfully edited!";

                return RedirectToAction("All");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ViewCloth(int id)
        {
            try
            {
                var clothModel = await clothesService.ViewClothAsync(id);
                var reviewModel = new ReviewViewModel();

                var viewModel = new ClothReviewViewModel
                {
                    Cloth = clothModel,
                    Review = reviewModel
                };

                return View(viewModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ViewTypeOfCloth(string gender, string clothing)
        {
            try
            {
                var model = await clothesService.ReturnTypeOfClothesAsync(gender, clothing);

                return View(model);
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
