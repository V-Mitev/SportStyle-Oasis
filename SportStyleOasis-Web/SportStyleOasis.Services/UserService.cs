namespace SportStyleOasis.Services
{
    using Microsoft.EntityFrameworkCore;
    using SportStyleOasis.Data;
    using SportStyleOasis.Services.Interfces;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly SportStyleOasisDbContext dbContext;

        public UserService(SportStyleOasisDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string> GetUserFullNameByIdAsync(string userId)
        {
            var user = await dbContext.ApplicationUsers
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }

        public async Task<bool> IsThisUserPostThisReview(string userId, int? reviewId)
        {
            var user = await dbContext.ApplicationUsers
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            var userName = $"{user?.FirstName} {user?.LastName}";

            var review = await dbContext.Review
                .FirstOrDefaultAsync(r => r.Id == reviewId);

            if (review?.UserName != userName)
            {
                return false;
            }

            return true;
        }
    }
}
