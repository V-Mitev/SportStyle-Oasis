namespace SportStyleOasis.Services
{
    using Microsoft.EntityFrameworkCore;
    using SportStyleOasis.Data;
    using SportStyleOasis.Services.Interfces;
    using SportStyleOasis.Web.ViewModels.ProteinPowder;

    public class ProteinPowderService : IProteinPowderService
    {
        private readonly SportStyleOasisDbContext dbContext;

        public ProteinPowderService(SportStyleOasisDbContext dbContext)
        {
            this.dbContext = dbContext;       
        }

        public async Task<IEnumerable<AllProteinPowderViewModel>> AllAsync()
        {
            return await dbContext.ProteinPowder
                .Select(pp => new AllProteinPowderViewModel()
                {
                    Name = pp.Name,
                    Taste = pp.Taste,
                    Price = pp.Price,
                    Image = pp.Image,
                    Weight = pp.Weight,
                    Brand = pp.ProteinPowderBrands.ToString(),
                    ProteinType = pp.TypeOfProtein.ToString(),
                })
                .ToListAsync();
        }
    }
}
