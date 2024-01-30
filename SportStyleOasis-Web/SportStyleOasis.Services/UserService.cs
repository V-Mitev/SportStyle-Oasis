namespace SportStyleOasis.Services
{
    using Microsoft.EntityFrameworkCore;
    using SportStyleOasis.Data;
    using SportStyleOasis.Services.Interfces;
    using SportStyleOasis.Web.ViewModels.User;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly SportStyleOasisDbContext dbContext;

        public UserService(SportStyleOasisDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task DeleteUserByIdAsync(string userId)
        {
            var user = await dbContext.ApplicationUsers
                .FirstAsync(u => u.Id.ToString() == userId);

            dbContext.ApplicationUsers.Remove(user);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserViewModel>> GetAllUsersAsync()
        {
            return await dbContext.ApplicationUsers
                .Select(u => new UserViewModel()
                {
                    Id = u.Id.ToString(),
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    FullName = u.FirstName + " " + u.LastName
                }).ToListAsync();
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

        public async Task<bool> IsThisUserPostThisReview(string userId, int? reviewId, bool isUserAdmin)
        {
            if (isUserAdmin)
            {
                return true;
            }

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
