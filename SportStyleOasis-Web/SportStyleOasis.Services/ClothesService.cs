﻿namespace SportStyleOasis.Services
{
    using Microsoft.EntityFrameworkCore;
    using SportStyleOasis.Data;
    using SportStyleOasis.Data.Models;
    using SportStyleOasis.Data.Models.Enums;
    using SportStyleOasis.Services.Data.Models.Clothes;
    using SportStyleOasis.Services.Interfces;
    using SportStyleOasis.Web.ViewModels.Clothes;
    using SportStyleOasis.Web.ViewModels.ClothInventory;
    using SportStyleOasis.Web.ViewModels.Review;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ClothesService : IClothesService
    {
        private readonly SportStyleOasisDbContext dbContext;

        public ClothesService(SportStyleOasisDbContext data)
        {
            dbContext = data;
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
                    Clothe = clothe,
                    ClothesSize = kvp.Key
                };

                clothe.ClotheInventories.Add(clotheInventory);
            }

            await dbContext.Clothes.AddAsync(clothe);
            await dbContext.SaveChangesAsync();
        }

        public async Task<AllClothesFilteredAndPagedServiceModel> AllAsync(AllClothesQueryModel queryModel)
        {
            IQueryable<Clothes> clothesQuery = dbContext.Clothes
                .AsQueryable();

            if (queryModel.Gender.HasValue)
            {
                clothesQuery = clothesQuery
                    .Where(c => c.ClothesForGender == queryModel.Gender);
            }

            if (queryModel.TypeOfClothe.HasValue)
            {
                clothesQuery = clothesQuery
                    .Where(c => c.TypeOfClothes == queryModel.TypeOfClothe);
            }

            if (queryModel.ClotheBrand.HasValue)
            {
                clothesQuery = clothesQuery
                    .Where(c => c.ClothesBrands == queryModel.ClotheBrand);
            }

            if (!string.IsNullOrEmpty(queryModel.SearchString))
            {
                var wildCard = $"%{queryModel.SearchString.ToLower()}%";

                clothesQuery = clothesQuery
                    .Where(c => EF.Functions.Like(c.Name, wildCard));
            }

            var allClothes = await clothesQuery
                .Skip((queryModel.CurrentPage - 1) * queryModel.ClothesPerPage)
                .Take(queryModel.ClothesPerPage)
                .Select(c => new AllClothesViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Image = c.Image,
                    Price = c.Price
                })
                .ToListAsync();

            int totalClothes = clothesQuery.Count();

            return new AllClothesFilteredAndPagedServiceModel()
            {
                Clothes = allClothes,
                TotalClothesCount = totalClothes,
            };
        }

        public async Task<int> AllClothesCount()
        {
            return await dbContext.Clothes.CountAsync();
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

        public async Task<UpdateClothViewModel> FindGarmentToUpdateAsync(int id)
        {
            var garment =
                await dbContext.Clothes.FirstOrDefaultAsync(g => g.Id == id);

            if (garment == null)
            {
                throw new InvalidOperationException($"Garment with ID {id} not found.");
            }

            var oldGarment = new UpdateClothViewModel()
            {
                Id = garment.Id,
                Name = garment.Name,
                Color = garment.Color,
                Price = garment.Price,
                Image = garment.Image,
                Description = garment.Description,
                ClothType = (TypeOfClothes)garment.TypeOfClothes!,
                ClothBrand = (ClothesBrands)garment.ClothesBrands!,
                ClothForGender = (Gender)garment.ClothesForGender!
            };

            return oldGarment;
        }

        public async Task<IEnumerable<Clothes>> GetAvailableColorsForClothAsync(string clothName, bool isUserAdmin)
        {
            if (string.IsNullOrEmpty(clothName))
            {
                throw new InvalidOperationException("This cloth name doesn't exist.");
            }

            var equalsClothes = await dbContext.Clothes
                .Include(c => c.ClotheInventories)
                .Where(c => c.Name == clothName)
                .ToListAsync();

            if (isUserAdmin)
            {
                return equalsClothes;
            }

            var availableColors = new HashSet<Clothes>();

            foreach (var cloth in equalsClothes)
            {
                foreach (var clothInventory in cloth.ClotheInventories)
                {
                    if (clothInventory.AvailableQuantity > 0)
                    {
                        availableColors.Add(cloth);
                    }
                }
            }

            return availableColors;
        }

        public async Task<string> GetClotheName(int clothId)
        {
            var clothName = await dbContext.Clothes
                .Where(c => c.Id == clothId)
                .Select(c => c.Name)
                .FirstOrDefaultAsync();

            if (clothName == null)
            {
                throw new InvalidOperationException("This cloth do not exists");
            }

            return clothName;
        }

        public async Task<Clothes> GetClothesWithFilteredInventory(int clothId, string clothSize)
        {
            var cloth = await dbContext.Clothes
            .Include(c => c.ClotheInventories)
            .FirstOrDefaultAsync(c => c.Id == clothId);

            if (cloth == null)
            {
                throw new
                    InvalidOperationException($"Clothe was not found. PLease contact with the administrator");
            }

            // If cloth is found, filter its inventory by the provided clothSize
            // Filter the inventories dynamically based on clothSize
            cloth.ClotheInventories = cloth.ClotheInventories
                    .Where(ci => ci.ClothesSize.ToString()!.ToLower() == clothSize.ToLower())
                    .ToList();

            return cloth;
        }

        public async Task<IEnumerable<AllClothesViewModel>> ReturnTypeOfClothesAsync(string gender, string typeOfClothes)
        {
            var genderEnum = (Gender)Enum.Parse(typeof(Gender), gender);
            var typeOfClothesEnum = (TypeOfClothes)Enum.Parse(typeof(TypeOfClothes), typeOfClothes);

            return await dbContext.Clothes
                .Where(c => (c.ClothesForGender == genderEnum || c.ClothesForGender == Gender.Unisex) &&
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

        public async Task UpdateGarmentAsync(int id, UpdateClothViewModel model)
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
            oldGarment.TypeOfClothes = model.ClothType;
            oldGarment.ClothesBrands = model.ClothBrand;
            oldGarment.ClothesForGender = model.ClothForGender;

            await dbContext.SaveChangesAsync();
        }

        public async Task<ClothViewModel> ViewClothAsync(int id)
        {
            var currentGarment = await dbContext.Clothes
                .Include(c => c.ClotheInventories)
                .Include(c => c.Reviews)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (currentGarment == null)
            {
                throw new InvalidOperationException($"Garment with ID {id} not found.");
            }

            var viewCloth = new ClothViewModel()
            {
                Id = currentGarment.Id,
                Name = currentGarment.Name,
                Color = currentGarment.Color,
                Price = currentGarment.Price,
                Image = currentGarment.Image,
                Description = currentGarment.Description,
                ClothType = (TypeOfClothes)currentGarment.TypeOfClothes!,
                Reviews = currentGarment.Reviews
                    .OrderByDescending(r => r.CreatedAt)
                    .Select(r => new ReviewViewModel()
                    {
                        Id = r.Id,
                        UserName = r.UserName,
                        Comment = r.Comment,
                        Rating = r.Rating,
                        CreatedAt = r.CreatedAt,
                    })
                    .ToList(),
                ClothInventory = currentGarment.ClotheInventories
                    .OrderBy(ci => ci.ClothesSize)
                    .Select(ci => new ClothInventoryViewModel()
                    {
                        Id = ci.Id,
                        AvailableQuantity = ci.AvailableQuantity,
                        ClothesSize = ci.ClothesSize
                    }).ToList()
            };

            return viewCloth;
        }
    }
}
