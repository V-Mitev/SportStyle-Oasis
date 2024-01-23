namespace SportStyleOasis.Services
{
    using Microsoft.EntityFrameworkCore;
    using SportStyleOasis.Data;
    using SportStyleOasis.Data.Models;
    using SportStyleOasis.Services.Interfces;
    using SportStyleOasis.Web.ViewModels.Review;
    using System.Threading.Tasks;

    public class ReviewService : IReviewService
    {
        private readonly SportStyleOasisDbContext dbContext;

        public ReviewService(SportStyleOasisDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddReview(ReviewViewModel model, int clothId, int proteinPowderId, string userFullName)
        {
            var review = new Review()
            {
                Rating = model.Rating,
                Comment = model.Comment,
                CreatedAt = DateTime.UtcNow,
                UserName = userFullName
            };

            if (clothId == 0)
            {
                review.ProteinPowderId = proteinPowderId;
            }
            else
            {
                review.ClothesId = clothId;
            }

            await dbContext.Review.AddAsync(review);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ReviewViewModel> EditReview(int reviewId, string editedComment, int editedRating)
        {
            var review = await dbContext.Review.FirstAsync(r => r.Id == reviewId);

            review.Rating = editedRating;
            review.Comment = editedComment;

            await dbContext.SaveChangesAsync();

            var reiewViewModel = new ReviewViewModel()
            {
                Id = reviewId,
                Comment = review.Comment,
                Rating = review.Rating,
                CreatedAt = review.CreatedAt,
                UserName = review.UserName
            };

            return reiewViewModel;
        }
    }
}
