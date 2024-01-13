namespace SportStyleOasis.Services
{
    using Microsoft.EntityFrameworkCore;
    using SportStyleOasis.Data;
    using SportStyleOasis.Data.Models;
    using SportStyleOasis.Services.Interfces;
    using SportStyleOasis.Web.ViewModels.ProteinFlavor;
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
                    Id = pp.Id,
                    Name = pp.Name,
                    Price = pp.Price,
                    Image = pp.Image,
                    ProteinPowderBrand = pp.ProteinPowderBrands,
                })
                .ToListAsync();
        }

        public async Task DeleteProteinPowder(int id)
        {
            var proteinPowder = await dbContext.ProteinPowder
                .FirstOrDefaultAsync(pp => pp.Id == id);

            if (proteinPowder == null)
            {
                throw new InvalidOperationException($"This protein powder with {id} was not found!");
            }

            dbContext.ProteinPowder.Remove(proteinPowder);
            await dbContext.SaveChangesAsync();
        }

        public async Task EditProteinPowder(int id, AddProteinPowderViewModel model)
        {
            var proteinPowder = await dbContext.ProteinPowder
                .Include(pp => pp.ProteinFlavors)
                .FirstOrDefaultAsync(pp => pp.Id == id);

            if (proteinPowder == null)
            {
                throw new InvalidOperationException($"This protein powder with {id} was not found!");
            }

            proteinPowder.Name = model.Name;
            proteinPowder.Image = model.Image;
            proteinPowder.Price = model.Price;
            proteinPowder.Weight = model.Weight;
            proteinPowder.Description = model.Description;
            proteinPowder.TypeOfProtein = model.TypeOfProtein;
            proteinPowder.ProteinPowderBrands = model.ProteinPowderBrands;

            await dbContext.SaveChangesAsync();
        }

        public async Task<ProteinPowderViewModel> FindProteinPowder(int id)
        {
            var proteinPowder = await dbContext.ProteinPowder
                .Include(pp => pp.ProteinFlavors)
                .FirstOrDefaultAsync(pp => pp.Id == id);

            if (proteinPowder == null)
            {
                throw new InvalidOperationException($"This protein powder with {id} was not found!");
            }

            var proteinPowderModel = new ProteinPowderViewModel()
            {
                Id = proteinPowder!.Id,
                Name = proteinPowder.Name,
                Image = proteinPowder.Image,
                Price = proteinPowder.Price,
                Weight = proteinPowder.Weight,
                Description = proteinPowder.Description,
                TypeOfProtein = proteinPowder.TypeOfProtein,
                ProteinPowderBrand = proteinPowder.ProteinPowderBrands
            };

            foreach (var proteinFlavors in proteinPowder.ProteinFlavors.OrderBy(pf => pf.FlavorName))
            {
                if (proteinFlavors.Quantity > 0)
                {
                    var flavor = new ProteinFlavorViewModel()
                    {
                        Quantity = proteinFlavors.Quantity,
                        FlavorName = proteinFlavors.FlavorName
                    };

                    proteinPowderModel.ProteinFlavors.Add(flavor);
                }
            }

            return proteinPowderModel;
        }

        public async Task<AddProteinPowderViewModel> FindProteinPowderForEdit(int id)
        {
            var proteinPowder = await dbContext.ProteinPowder
                .FirstOrDefaultAsync(pp => pp.Id == id);

            if (proteinPowder == null)
            {
                throw new InvalidOperationException($"This protein powder with {id} was not found!");
            }

            var proteinPowderModel = new AddProteinPowderViewModel()
            {
                Name = proteinPowder.Name,
                Image = proteinPowder.Image,
                Price = proteinPowder.Price,
                Weight = proteinPowder.Weight,
                Description = proteinPowder.Description,
                TypeOfProtein = proteinPowder.TypeOfProtein,
                ProteinPowderBrands = proteinPowder.ProteinPowderBrands
            };

            return proteinPowderModel;
        }
    }
}
