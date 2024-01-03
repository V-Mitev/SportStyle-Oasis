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
                    Image = "gray_tshirt.jpg",
                    AvailabeQuantity = 10,
                    Size = ClothesSize.M,
                    TypeOfClothes = TypeOfClothes.TShirt,
                },
                new Clothes()
                {
                    Id = 2,
                    Name = "T-shirt-Black",
                    Price = 9.99M,
                    Color = "Black",
                    Image = "black_tshirt.jpg",
                    AvailabeQuantity = 10,
                    Size = ClothesSize.L,
                    TypeOfClothes = TypeOfClothes.TShirt,
                },
                new Clothes()
                {
                    Id = 3,
                    Name = "T-shirt-White",
                    Price = 10.99M,
                    Color = "White",
                    Image = "white_tshirt.jpg",
                    AvailabeQuantity = 10,
                    Size = ClothesSize.XL,
                    TypeOfClothes = TypeOfClothes.TShirt,
                }
            };

            return clothes;
        }
    }
}
