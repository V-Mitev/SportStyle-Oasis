namespace SportStyleOasis.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SportStyleOasis.Data.Models;
    using SportStyleOasis.Data.Models.Enums;

    public class ClothesConfiguration : IEntityTypeConfiguration<Clothes>
    {
        public void Configure(EntityTypeBuilder<Clothes> builder)
        {
            builder.HasData(GeneretaClothes());
        }

        private static ICollection<Clothes> GeneretaClothes()
        {
            ICollection<Clothes> clothes = new HashSet<Clothes>()
            {
                new Clothes()
                {
                    Id = 1,
                    Name = "T-shirt-Gray",
                    Price = 13.99M,
                    Color = "Gray",
                    ClothesBrands = ClothesBrands.Nike,
                    Image = "gray_tshirt.jpg",
                    AvailabeQuantity = 10,
                    Size = ClothesSize.M,
                    TypeOfClothes = TypeOfClothes.TShirt,
                    ClothesForGender = Gender.Male,
                    Description = "This is test description about this tshirt"
                },
                new Clothes()
                {
                    Id = 2,
                    Name = "T-shirt-Black",
                    Price = 9.99M,
                    Color = "Black",
                    ClothesBrands = ClothesBrands.UnderArmour,
                    Image = "black_tshirt.jpg",
                    AvailabeQuantity = 10,
                    Size = ClothesSize.L,
                    TypeOfClothes = TypeOfClothes.TShirt,
                    ClothesForGender = Gender.Male,
                    Description = "This is test description about this tshirt"
                },
                new Clothes()
                {
                    Id = 3,
                    Name = "T-shirt-White",
                    Price = 10.99M,
                    Color = "White",
                    ClothesBrands = ClothesBrands.Puma,
                    Image = "white_tshirt.jpg",
                    AvailabeQuantity = 10,
                    Size = ClothesSize.XL,
                    TypeOfClothes = TypeOfClothes.TShirt,
                    ClothesForGender = Gender.Female,
                    Description = "This is test description about this tshirt"
                }
            };

            return clothes;
        }
    }
}
