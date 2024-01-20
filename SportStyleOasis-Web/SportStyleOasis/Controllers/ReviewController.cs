namespace SportStyleOasis.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SportStyleOasis.Services.Interfces;
    using SportStyleOasis.Web.Infrastructure.Extensions;
    using SportStyleOasis.Web.ViewModels.ClothReview;
    using SportStyleOasis.Web.ViewModels.ProteinReview;
    using static SportStyleOasis.Common.NotificationMessagesConstant;

    [Authorize]
    public class ReviewController : Controller
    {
        public readonly IReviewService reviewService;
        private readonly IUserService userService;

        public ReviewController(IReviewService reviewService, IUserService userService)
        {
            this.reviewService = reviewService;
            this.userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> AddClotheReview(ClothReviewViewModel model, int clothId)
        {
            if (clothId == 0)
            {
                return GeneralError();
            }

            if (model.Review.Comment == null || model.Review.Rating == 0)
            {
                TempData[ErrorMessage] = "Please fill in all fields before submitting your review.";

                return RedirectToAction("ViewCloth", "Clothes", new { id = clothId });
            }

            var userFullName = await userService.GetUserFullNameByIdAsync(User.GetId());

            try
            {
                await reviewService.AddReview(model.Review, clothId, 0,userFullName);

                return RedirectToAction("ViewCloth", "Clothes", new { id = clothId });
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProteinPowderReview(ProteinPowderReviewViewModel model, int proteinPowderId)
        {
            if (proteinPowderId == 0)
            {
                return GeneralError();
            }

            if (model.Review.Comment == null || model.Review.Rating == 0)
            {
                TempData[ErrorMessage] = "Please fill in all fields before submitting your review.";

                return RedirectToAction("ViewProteinPowder", "ProteinPowder", new { id = proteinPowderId });
            }

            var userFullName = await userService.GetUserFullNameByIdAsync(User.GetId());

            try
            {
                await reviewService.AddReview(model.Review, 0, proteinPowderId, userFullName);

                return RedirectToAction("ViewProteinPowder", "ProteinPowder", new { id = proteinPowderId });
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
