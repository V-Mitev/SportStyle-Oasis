namespace SportStyleOasis.Services
{
    using SportStyleOasis.Data;
    using SportStyleOasis.Data.Models;
    using SportStyleOasis.Services.Interfces;
    using System.Threading.Tasks;

    public class ProteinOrderQuantityService : IProteinOrderQuantityService
    {
        private readonly SportStyleOasisDbContext dbContext;

        public ProteinOrderQuantityService(SportStyleOasisDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ProteinOrderQuantity> AddProteinOrderQuantityAsync(int orderedQuantity)
        {
            var proteinOrderQuantity = new ProteinOrderQuantity()
            {
                Quantity = orderedQuantity
            };

            await dbContext.ProteinOrderQuantities.AddAsync(proteinOrderQuantity);
            await dbContext.SaveChangesAsync();

            return proteinOrderQuantity;
        }
    }
}
