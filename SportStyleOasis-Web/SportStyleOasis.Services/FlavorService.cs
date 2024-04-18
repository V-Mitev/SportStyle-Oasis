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
                    Quantity = f.Quantity,
                    ProteinPowderId = proteinPowderId
                })
                .ToListAsync();
        }

        public async Task EditFlavor(ICollection<ProteinFlavorViewModel> model, int proteinPowderId)
        {
            var flavors = await dbContext.ProteinFlavor
                .Where(f => f.ProteinId == proteinPowderId)
                .ToListAsync();

            foreach (var flavor in model)
            {
                var flavorToEdit = flavors.First(f => f.Id == flavor.Id);

                flavorToEdit.FlavorName = flavor.FlavorName;
                flavorToEdit.Quantity = flavor.Quantity;
            }

            await dbContext.SaveChangesAsync();
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

        public async Task<ProteinFlavor> GetProteinFlavorAsync(int proteinId, string proteinFlavor)
        {
            var proteinFlavorModel = await dbContext.ProteinFlavor
                .Include(pf => pf.Protein)
                .FirstOrDefaultAsync(pf => pf.ProteinId == proteinId && pf.FlavorName == proteinFlavor);

            if (proteinFlavorModel == null)
            {
                throw new InvalidOperationException("This protein flavor was not found to add it in cart.");
            }

            return proteinFlavorModel;
        }

        public async Task DeleteProteinFlavorByIdAsync(int proteinFlavorId)
        {
            var proteinFlavor = await dbContext.ProteinFlavor
                .FirstAsync(pf => pf.Id == proteinFlavorId);

            dbContext.ProteinFlavor.Remove(proteinFlavor);
            await dbContext.SaveChangesAsync();
        }
    }
}
