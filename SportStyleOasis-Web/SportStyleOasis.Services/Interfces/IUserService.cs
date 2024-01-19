namespace SportStyleOasis.Services.Interfces
{
    public interface IUserService
    {
        public Task<string> GetUserFullNameByIdAsync(string userId);
    }
}
