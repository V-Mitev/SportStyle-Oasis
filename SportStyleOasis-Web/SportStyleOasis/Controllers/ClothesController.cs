﻿namespace SportStyleOasis.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SportStyleOasis.Data.Models.Enums;
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

            foreach (var clotheSize in Enum.GetValues(typeof(ClothesSize)).Cast<ClothesSize>())
            {
                model.SizesAndQuantities[clotheSize] = 0;
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddClotheViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
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

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await clothesService.DeleteGarmentAsync(id);

                TempData[SuccessMessage] = "You have successfully delete this garmnet.";

                return RedirectToAction("All", "Clothes");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await clothesService.FindGarmentToUpdateAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateGarmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await clothesService.UpdateGarmentAsync(id, model);

                TempData[SuccessMessage] = $"The garment '{model.Name}' was successfully edited!";

                return RedirectToAction("All");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> ViewCloth(int id)
        {
            try
            {
                var model = await clothesService.ViewClothAsync(id);

                return View(model);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
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
