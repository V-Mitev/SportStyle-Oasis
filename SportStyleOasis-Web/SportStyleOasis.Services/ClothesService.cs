namespace SportStyleOasis.Services
{
    using Microsoft.EntityFrameworkCore;
    using SportStyleOasis.Data;
    using SportStyleOasis.Data.Models;
    using SportStyleOasis.Data.Models.Enums;
    using SportStyleOasis.Services.Interfces;
    using SportStyleOasis.Web.ViewModels.Clothes;
    using SportStyleOasis.Web.ViewModels.ClothInventory;
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

            foreach (var kvp in model.SizesAndQuantities)
            {
                ClotheInventory clotheInventory = new ClotheInventory()
                {
                    AvailableQuantity = kvp.Value,
                    ClothId = clothe.Id,
                    Clothes = clothe,
                    ClothesSize = kvp.Key
                };

                clothe.ClotheInventories.Add(clotheInventory);
            }

            await dbContext.Clothes.AddAsync(clothe);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllClothesViewModel>> AllAsync()
        {
            return await dbContext.Clothes
                .Select(c => new AllClothesViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Price = c.Price,
                    Image = c.Image
                })
                .ToListAsync();
        }

        public async Task DeleteGarmentAsync(int id)
        {
            var garment = await dbContext.Clothes.FirstOrDefaultAsync(g => g.Id == id);

            if (garment == null)
            {
                throw new InvalidOperationException($"Garment with ID {id} not found.");
            }

            dbContext.Clothes.Remove(garment);
            await dbContext.SaveChangesAsync();
        }

        public async Task<UpdateGarmentViewModel> FindGarmentToUpdate(int id)
        {
            var garment =
                await dbContext.Clothes.FirstOrDefaultAsync(g => g.Id == id);

            if (garment == null)
            {
                throw new InvalidOperationException($"Garment with ID {id} not found.");
            }

            var oldGarment = new UpdateGarmentViewModel()
            {
                Id = garment.Id,
                Name = garment.Name,
                Color = garment.Color,
                Price = garment.Price,
                Image = garment.Image,
                Description = garment.Description,
                GarmentType = (TypeOfClothes)garment.TypeOfClothes!,
                GarmentBrand = (ClothesBrands)garment.ClothesBrands!,
                GarmentForGender = (Gender)garment.ClothesForGender!
            };

            return oldGarment;
        }

        public async Task<IEnumerable<AllClothesViewModel>> ReturnTypeOfClothes(string gender, string typeOfClothes)
        {
            var genderEnum = (Gender)Enum.Parse(typeof(Gender), gender);
            var typeOfClothesEnum = (TypeOfClothes)Enum.Parse(typeof(TypeOfClothes), typeOfClothes);

            return await dbContext.Clothes
                .Where(c => c.ClothesForGender == genderEnum ||
                        c.ClothesForGender == Gender.Unisex &&
                        c.TypeOfClothes == typeOfClothesEnum)
                .Select(c => new AllClothesViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Image = c.Image,
                    Price = c.Price
                })
                .ToListAsync();
        }

        public async Task UpdateGarment(int id, UpdateGarmentViewModel model)
        {
            var oldGarment =
                await dbContext.Clothes.FirstOrDefaultAsync(g => g.Id == id);

            if (oldGarment == null)
            {
                throw new InvalidOperationException($"Garment with ID {id} not found.");
            }

            oldGarment.Name = model.Name;
            oldGarment.Color = model.Color;
            oldGarment.Price = model.Price;
            oldGarment.Image = model.Image;
            oldGarment.Description = model.Description;
            oldGarment.TypeOfClothes = model.GarmentType;
            oldGarment.ClothesBrands = model.GarmentBrand;
            oldGarment.ClothesForGender = model.GarmentForGender;

            await dbContext.SaveChangesAsync();
        }

        public async Task<ClothViewModel> ViewCloth(int id)
        {
            var currentGarment = await dbContext.Clothes
                .Include(c => c.ClotheInventories)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (currentGarment == null)
            {
                throw new InvalidOperationException($"Garment with ID {id} not found.");
            }

            var viewCloth = new ClothViewModel()
            {
                Name = currentGarment.Name,
                Color = currentGarment.Color,
                Price = currentGarment.Price,
                Image = currentGarment.Image,
                Description = currentGarment.Description,
                GarmentType = (TypeOfClothes)currentGarment.TypeOfClothes!
            };

            foreach (var clotheInventory in currentGarment.ClotheInventories.OrderBy(ci => ci.ClothesSize))
            {
                var clothInventoryViewModel = new ClothInventoryViewModel()
                {
                    AvailableQuantity = clotheInventory.AvailableQuantity,
                    ClothesSize = clotheInventory.ClothesSize
                };

                viewCloth.ClothInventory.Add(clothInventoryViewModel);
            }

            return viewCloth;
        }
    }
}
