namespace SportStyleOasis.Services
{
    using Microsoft.EntityFrameworkCore;
    using SportStyleOasis.Data;
    using SportStyleOasis.Data.Models;
    using SportStyleOasis.Services.Interfces;
    using SportStyleOasis.Web.ViewModels.ProteinFlavor;
    using System.Threading.Tasks;

    public class FlavorService : IFlavorService
    {
        private readonly SportStyleOasisDbContext dbContext;

        public FlavorService(SportStyleOasisDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddFlavorAsync(ProteinFlavorViewModel model, string proteinPowderName)
        {
            var proteinPowder = await dbContext.ProteinPowder
                .FirstOrDefaultAsync(pp => pp.Name == proteinPowderName);

            if (proteinPowder == null)
            {
                throw new InvalidOperationException($"Protein Powder {proteinPowderName} was not found!");
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
    }
}
