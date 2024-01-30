namespace SportStyleOasis.Services.Interfces
{
    using SportStyleOasis.Web.ViewModels.User;

    public interface IUserService
    {
        public Task<string> GetUserFullNameByIdAsync(string userId);

        public Task<bool> IsThisUserPostThisReview(string userId, int? reviewId, bool isUserAdmin);

        public Task<IEnumerable<UserViewModel>> GetAllUsersAsync();

        public Task DeleteUserByIdAsync(string userId);
    }
}
