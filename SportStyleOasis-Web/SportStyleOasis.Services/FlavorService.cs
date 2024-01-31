namespace SportStyleOasis.Services
{
    using Microsoft.EntityFrameworkCore;
    using SportStyleOasis.Data;
    using SportStyleOasis.Data.Models;
    using SportStyleOasis.Services.Interfces;
    using SportStyleOasis.Web.ViewModels.ProteinFlavor;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class FlavorService : IFlavorService
    {
        private readonly SportStyleOasisDbContext dbContext;

        public FlavorService(SportStyleOasisDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddFlavorAsync(ProteinFlavorViewModel model, int id)
        {
            var proteinPowder = await dbContext.ProteinPowder
                .FirstOrDefaultAsync(pp => pp.Id == id);

            if (proteinPowder == null)
            {
                throw new InvalidOperationException($"Protein Powder with this id: {id} was not found!");
            }

            var flavor = new ProteinFlavor()
            {
                Protein = proteinPowder,
                Quantity = model.Quantity,
                ProteinId = proteinPowder.Id,
                FlavorName = model.FlavorName,
            };

            proteinPowder.ProteinFlavors.Add(flavor);

            await dbContext.ProteinFlavor.AddAsync(flavor);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<ProteinFlavorViewModel>> AllProteinFlavorsAsync(int proteinPowderId)
        {
            return await dbContext.ProteinFlavor
                .Where(f => f.ProteinId == proteinPowderId)
                .Select(f => new ProteinFlavorViewModel()
                {
                    Id = f.Id,
                    FlavorName = f.FlavorName,
                    Quantity = f.Quantity
                })
                .ToListAsync();
        }

        public async Task<bool> IsFlavorAlreadyAdded(int proteinPowderId, string flavorName)
        {
            var proteinPowder = await dbContext.ProteinPowder
                .FirstOrDefaultAsync(pp => pp.Id == proteinPowderId);

            if (proteinPowder == null)
            {
                throw new InvalidOperationException($"Protein Powder with this id: {proteinPowderId} was not found!");
            }

            return
               proteinPowder.ProteinFlavors.Any(pf => pf.FlavorName.ToLower() == flavorName.ToLower());
        }
    }
}
