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
        public async Task<IActionResult> AddClotheReview(ClothReviewViewModel model, int clothId, string userId)
        {
            if (model.Review.Rating == 0)
            {
                TempData[ErrorMessage] = "Please select rating before submitting your review.";

                return RedirectToAction("ViewCloth", "Clothes", new { id = clothId });
            }

            if (clothId == 0 || userId == null)
            {
                return GeneralError();
            }

            try
            {
                var userFullName = await userService.GetUserFullNameByIdAsync(userId);

                await reviewService.AddReviewAsync(model.Review, clothId, 0, userFullName);

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

            if (model.Review.Rating == 0)
            {
                TempData[ErrorMessage] = "Please select rating before submitting your review.";

                return RedirectToAction("ViewProteinPowder", "ProteinPowder", new { id = proteinPowderId });
            }

            try
            {
                var userFullName = await userService.GetUserFullNameByIdAsync(User.GetId());

                await reviewService.AddReviewAsync(model.Review, 0, proteinPowderId, userFullName);

                return RedirectToAction("ViewProteinPowder", "ProteinPowder", new { id = proteinPowderId });
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditReview(int reviewId, string editedComment, int editedRating)
        {
            try
            {
                var model = await reviewService.EditReviewAsync(reviewId, editedComment, editedRating);

                return Ok(model);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReview(int reviewId)
        {
            if (reviewId == 0)
            {
                return GeneralError();
            }

            try
            {
                await reviewService.DeleteReviewByIdAsync(reviewId);

                return Ok();
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
