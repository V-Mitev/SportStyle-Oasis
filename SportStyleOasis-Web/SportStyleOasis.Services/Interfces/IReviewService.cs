namespace SportStyleOasis.Services.Interfces
{
    using SportStyleOasis.Web.ViewModels.Review;

    public interface IReviewService
    {
        public Task AddReviewAsync(ReviewViewModel model, int clothId, int proteinPowderId, string userFullName);

        public Task<ReviewViewModel> EditReviewAsync(int reviewId, string editedComment, int editedRating);

        public Task<bool> IsUserAddReviewToClotheAsync(string userId, int clothId);

        public Task<bool> IsUserAddReviewToProteinPowderAsync(string userId, int proteinPowderId);

        public Task DeleteReviewByIdAsync(int reviewId);
    }
}
