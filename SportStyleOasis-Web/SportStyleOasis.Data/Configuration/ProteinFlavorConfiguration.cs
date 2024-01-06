namespace SportStyleOasis.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SportStyleOasis.Data.Models;

    public class ProteinFlavorConfiguration : IEntityTypeConfiguration<ProteinFlavor>
    {
        public void Configure(EntityTypeBuilder<ProteinFlavor> builder)
        {
            builder.HasData(GenerateProteinFlavor());
        }

        private static IEnumerable<ProteinFlavor> GenerateProteinFlavor()
        {
            IEnumerable<ProteinFlavor> proteinFlavors = new HashSet<ProteinFlavor>()
            {
                new ProteinFlavor
                {
                    Id = 1,
                    FlavorName = "Iced Late",
                    ProteinId = 2,
                    Quantity = 10
                },
                new ProteinFlavor
                {
                    Id = 2,
                    FlavorName = "Salted Caramel",
                    ProteinId = 2,
                    Quantity = 10
                },
                new ProteinFlavor
                {
                    Id = 3,
                    FlavorName = "Pistachio Ice Cream",
                    ProteinId = 2,
                    Quantity = 10
                },
                new ProteinFlavor
                {
                    Id = 4,
                    FlavorName = "Banana",
                    ProteinId = 1,
                    Quantity = 10
                },
                new ProteinFlavor
                {
                    Id = 5,
                    FlavorName = "Cookies & Cream",
                    ProteinId = 3,
                    Quantity = 10
                }
            };

            return proteinFlavors;
        }
    }
}
