namespace SportStyleOasis.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SportStyleOasis.Services.Interfces;
    using SportStyleOasis.Web.ViewModels.Clothes;
    using static SportStyleOasis.Common.NotificationMessagesConstant;

    public class ClothesController : Controller
    {
        private readonly IClothesService clothesService;

        public ClothesController(IClothesService clothesService)
        {
            this.clothesService = clothesService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var clothes = await clothesService.AllAsync();

            return View(clothes);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddClotheViewModel model = new AddClotheViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddClotheViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Clothe"] = new AddClotheViewModel()
                {
                    Name = model.Name,
                    Price = model.Price,
                    Color = model.Color,
                    Image = model.Image,
                    ClotheSize = model.ClotheSize,
                    Description = model.Description,
                    ClothesBrands = model.ClothesBrands,
                    TypeOfClothes = model.TypeOfClothes,
                    ClothesForGender = model.ClothesForGender,
                    AvailableQuantity = model.AvailableQuantity
                };

                return View(TempData["Clothe"]);
            }

            try
            {
                await clothesService.AddClotheAsync(model);

                TempData[SuccessMessage] = "Successfully added clothe.";

                return RedirectToAction("All", "Clothes");
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
