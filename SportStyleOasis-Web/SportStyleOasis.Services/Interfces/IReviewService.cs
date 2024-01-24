namespace SportStyleOasis.Services.Interfces
{
    using SportStyleOasis.Web.ViewModels.Review;

    public interface IReviewService
    {
        public Task AddReview(ReviewViewModel model, int clothId, int proteinPowderId, string userFullName);

        public Task<ReviewViewModel> EditReview(int reviewId, string editedComment, int editedRating);

        public Task<bool> IsUserAddReviewToClothe(string userId, int clothId);

        public Task<bool> IsUserAddReviewToProteinPowder(string userId, int proteinPowderId);
    }
}
