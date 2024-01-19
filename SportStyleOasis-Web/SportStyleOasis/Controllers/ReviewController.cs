namespace SportStyleOasis.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SportStyleOasis.Services.Interfces;
    using SportStyleOasis.Web.Infrastructure.Extensions;
    using SportStyleOasis.Web.ViewModels.ClothReview;
    using static SportStyleOasis.Common.NotificationMessagesConstant;

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
        public async Task<IActionResult> Add(ClothReviewViewModel model, int clothId)
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
                await reviewService.AddReview(model.Review, clothId, userFullName);

                return RedirectToAction("ViewCloth", "Clothes", new { id = clothId });
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
