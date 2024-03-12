namespace SportStyleOasis.Services
{
    using SportStyleOasis.Data;
    using SportStyleOasis.Data.Models;
    using SportStyleOasis.Services.Interfces;
    using System.Threading.Tasks;

    public class ClothOrderQuantityService : IClothOrderQuantityService
    {
        private readonly SportStyleOasisDbContext dbContext;

        public ClothOrderQuantityService(SportStyleOasisDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ClotheOrderQuantity> AddClothOrderQuantityAsync(int orderedQuantity)
        {
            var clothOrderQuantity = new ClotheOrderQuantity()
            {
                Quantity = orderedQuantity
            };

            await dbContext.ClotheOrderQuantities.AddAsync(clothOrderQuantity);
            await dbContext.SaveChangesAsync();

            return clothOrderQuantity;
        }
    }
}
