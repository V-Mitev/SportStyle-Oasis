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

        public async Task<string> GetUserFullName(string? email)
        {
            var user = await dbContext.ApplicationUsers
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }
    }
}
