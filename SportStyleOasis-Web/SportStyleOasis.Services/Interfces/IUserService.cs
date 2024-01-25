namespace SportStyleOasis.Services.Interfces
{
    public interface IUserService
    {
        public Task<string> GetUserFullNameByIdAsync(string userId);

        public Task<bool> IsThisUserPostThisReview(string userId, int? reviewId, bool isUserAdmin);
    }
}
