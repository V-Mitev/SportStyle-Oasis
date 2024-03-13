namespace SportStyleOasis.Services.Interfces
{
    using SportStyleOasis.Data.Models;

    public interface IProteinOrderQuantityService
    {
        Task<ProteinOrderQuantity> AddProteinOrderQuantityAsync(int orderedQuantity);
    }
}
