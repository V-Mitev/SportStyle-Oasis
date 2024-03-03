namespace SportStyleOasis.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SportStyleOasis.Data.Models;
    using SportStyleOasis.Data.Models.Enums;

    public class ClotheInventoryConfiguration : IEntityTypeConfiguration<ClotheInventory>
    {
        public void Configure(EntityTypeBuilder<ClotheInventory> builder)
        {
            builder
                .HasOne(ci => ci.Clothe)
                .WithMany(ci => ci.ClotheInventories)
                .HasForeignKey(ci => ci.ClothId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(GenerateClotheInventory());
        }

        private static IEnumerable<ClotheInventory> GenerateClotheInventory()
        {
            IEnumerable<ClotheInventory> clotheInventories = new HashSet<ClotheInventory>()
            {
                new ClotheInventory
                {
                    Id = 1,
                    ClothId = 1,
                    ClothesSize = ClothesSize.XL,
                    AvailableQuantity = 10,
                },
                new ClotheInventory
                {
                    Id = 2,
                    ClothId = 2,
                    ClothesSize = ClothesSize.L,
                    AvailableQuantity = 10,
                },
                new ClotheInventory
                {
                    Id = 3,
                    ClothId = 3,
                    ClothesSize = ClothesSize.XS,
                    AvailableQuantity = 10,
                },
                new ClotheInventory
                {
                    Id = 4,
                    ClothId = 3,
                    ClothesSize = ClothesSize.S,
                    AvailableQuantity = 10,
                },
                new ClotheInventory
                {
                    Id = 5,
                    ClothId = 2,
                    ClothesSize = ClothesSize.M,
                    AvailableQuantity = 10,
                },
            };

            return clotheInventories;
        }
    }
}
