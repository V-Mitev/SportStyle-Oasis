namespace SportStyleOasis.Services
{
    using Microsoft.EntityFrameworkCore;
    using SportStyleOasis.Data;
    using SportStyleOasis.Data.Models;
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

        public async Task AddClotheAsync(AddClotheViewModel model)
        {
            Clothes clothe = new Clothes()
            {
                Name = model.Name,
                Price = model.Price,
                Color = model.Color,
                Image = model.Image,
                Description = model.Description,
                TypeOfClothes = model.TypeOfClothes,
                ClothesBrands = model.ClothesBrands,
                ClothesForGender = model.ClothesForGender
            };

            ClotheInventory clotheInventory = new ClotheInventory()
            {
                AvailableQuantity = model.AvailableQuantity,
                ClothId = clothe.Id,
                Clothes = clothe,
                ClothesSize = model.ClotheSize
            };

            clothe.ClotheInventories.Add(clotheInventory);

            await dbContext.Clothes.AddAsync(clothe);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllClothesModel>> AllAsync()
        {
            return await dbContext.Clothes
                .Select(c => new AllClothesModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Price = c.Price,
                    Color = c.Color,
                    Image = c.Image,
                    ClothSizes = c.ClotheInventories
                        .Where(ci => ci.Id == c.Id)
                        .Select(ci => ci.ClothesSize.ToString())
                        .ToList(),
                    ClothType = c.TypeOfClothes.ToString()
                })
                .ToListAsync();
        }
    }
}
