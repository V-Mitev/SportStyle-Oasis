namespace SportStyleOasis.Services
{
    using SportStyleOasis.Data;
    using SportStyleOasis.Data.Models;
    using SportStyleOasis.Services.Interfces;
    using SportStyleOasis.Web.ViewModels.ProteinReview;
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

        public async Task AddProteinPowderReview(ReviewViewModel model, int proteinPowderId, string userFullName)
        {
            var review = new Review()
            {
                Rating = model.Rating,
                Comment = model.Comment,
                CreatedAt = DateTime.UtcNow,
                UserName = userFullName
            };

            await dbContext.Review.AddAsync(review);
            await dbContext.SaveChangesAsync();
        }
    }
}
