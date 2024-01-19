namespace SportStyleOasis.Services.Interfces
{
    using SportStyleOasis.Web.ViewModels.Review;

    public interface IReviewService
    {
        public Task AddReview(ReviewViewModel model, int clothId, string userFullName);
    }
}
