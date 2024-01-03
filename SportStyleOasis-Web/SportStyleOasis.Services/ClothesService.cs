namespace SportStyleOasis.Services
{
    using Microsoft.EntityFrameworkCore;
    using SportStyleOasis.Data;
    using SportStyleOasis.Services.Interfces;
    using SportStyleOasis.Web.ViewModels.Clothes;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ClothesService : IClothesService
    {
        private readonly SportStyleOasisDbContext dbContext;

        public ClothesService(SportStyleOasisDbContext data)
        {
            this.dbContext = data;
        }

        public async Task<ICollection<AllClothesModel>> AllAsync()
        {
            return await dbContext.Clothes
                .Select(c => new AllClothesModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Price = c.Price,
                    Color = c.Color,
                    Image = c.Image,
                    ClothSize = c.Size.ToString(),
                    ClothType = c.TypeOfClothes.ToString()
                })
                .ToListAsync();
        }
    }
}
