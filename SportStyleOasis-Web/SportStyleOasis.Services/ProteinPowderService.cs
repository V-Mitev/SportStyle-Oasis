namespace SportStyleOasis.Services
{
    using Microsoft.EntityFrameworkCore;
    using SportStyleOasis.Data;
    using SportStyleOasis.Data.Models;
    using SportStyleOasis.Services.Interfces;
    using SportStyleOasis.Web.ViewModels.ProteinPowder;

    public class ProteinPowderService : IProteinPowderService
    {
        private readonly SportStyleOasisDbContext dbContext;

        public ProteinPowderService(SportStyleOasisDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(AddProteinPowderViewModel model)
        {
            var proteinPowder = new ProteinPowder()
            {
                Name = model.Name,
                Image = model.Image,
                Price = model.Price,
                Weight = model.Weight,
                Description = model.Description,
                TypeOfProtein = model.TypeOfProtein,
                ProteinPowderBrands = model.ProteinPowderBrands
            };

            await dbContext.ProteinPowder.AddAsync(proteinPowder);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllProteinPowderViewModel>> AllAsync()
        {
            return await dbContext.ProteinPowder
                .Select(pp => new AllProteinPowderViewModel()
                {
                    Name = pp.Name,
                    ProteinFlavor = pp.ProteinFlavors
                        .Where(pf => pf.ProteinId == pp.Id)
                        .Select(pf => pf.FlavorName)
                        .ToList(),
                    Price = pp.Price,
                    Image = pp.Image,
                    Weight = pp.Weight,
                    Brand = pp.ProteinPowderBrands.ToString()!,
                    ProteinType = pp.TypeOfProtein.ToString()!,
                })
                .ToListAsync();
        }
    }
}
