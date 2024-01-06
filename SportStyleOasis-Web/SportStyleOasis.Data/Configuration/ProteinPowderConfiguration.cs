namespace SportStyleOasis.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SportStyleOasis.Data.Models;
    using SportStyleOasis.Data.Models.Enums;

    public class ProteinPowderConfiguration : IEntityTypeConfiguration<ProteinPowder>
    {
        public void Configure(EntityTypeBuilder<ProteinPowder> builder)
        {
            builder.HasData(GenerateProteinPowders());
        }

        private static IEnumerable<ProteinPowder> GenerateProteinPowders()
        {
            IEnumerable<ProteinPowder> proteinPowders = new HashSet<ProteinPowder>()
            {
                new ProteinPowder()
                {
                    Id = 1,
                    Name = "Impact Whey Protein",
                    Price = 33.99M,
                    Image = "impact_whey_protein.jpg",
                    Weight = 1000,
                    TypeOfProtein = TypeOfProtein.WheyProtein,
                    ProteinPowderBrands = ProteinPowderBrands.MyProtein,
                },
                new ProteinPowder()
                {
                    Id = 2,
                    Name = "Pure Whey Protein Isolate",
                    Price = 54.99M,
                    Image = "bulk_isolate_protein.jpg",
                    Weight = 1000,
                    TypeOfProtein = TypeOfProtein.IsolateProtein,
                    ProteinPowderBrands = ProteinPowderBrands.Bulk,
                },
                new ProteinPowder()
                {
                    Id = 3,
                    Name = "Vegan Protein",
                    Price = 11.99M,
                    Image = "proteinWorks_vegan_protein.jpg",
                    Weight = 1000,
                    TypeOfProtein = TypeOfProtein.VeganProtein,
                    ProteinPowderBrands = ProteinPowderBrands.ProteinWorks,
                }
            };

            return proteinPowders;
        }
    }
}
