namespace SportStyleOasis.Services.Interfces
{
    public interface IUserService
    {
        public Task<string> GetUserFullName(string? email);
    }
}
