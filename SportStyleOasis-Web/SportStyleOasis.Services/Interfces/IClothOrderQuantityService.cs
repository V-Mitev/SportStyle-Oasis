namespace SportStyleOasis.Services.Interfces
{
    using SportStyleOasis.Data.Models;

    public interface IClothOrderQuantityService
    {
        Task<ClotheOrderQuantity> AddClothOrderQuantityAsync(int orderedQuantity);
    }
}
