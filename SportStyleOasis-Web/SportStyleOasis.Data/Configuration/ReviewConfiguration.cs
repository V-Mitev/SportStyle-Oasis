namespace SportStyleOasis.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SportStyleOasis.Data.Models;

    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder
                .HasOne(r => r.Clothes)
                .WithMany(c => c.Reviews)
                .HasForeignKey(r => r.ClothesId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(r => r.ProteinPowder)
                .WithMany(c => c.Reviews)
                .HasForeignKey(r => r.ProteinPowderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(GenerateReviews());
        }

        private static IEnumerable<Review> GenerateReviews()
        {
            IEnumerable<Review> reviews = new HashSet<Review>()
            {
                new Review()
                {
                    Id = 1,
                    ClothesId = 1,
                    Comment = "I really like the design and comfort of this gray T-shirt. Perfect for casual wear.",
                    UserName = "TestUserName",
                    CreatedAt = DateTime.UtcNow,
                    Rating = 4.5
                },
                new Review()
                {
                    Id = 2,
                    ClothesId = 2,
                    Comment = "The black T-shirt fits well and has a nice price. Great for everyday use.",
                    UserName = "TestUserName",
                    CreatedAt = DateTime.UtcNow,
                    Rating = 4
                },
                new Review()
                {
                    Id = 3,
                    ClothesId = 3,
                    Comment = "Absolutely love the style and feel of this white T-shirt. It's a must-have for any wardrobe!",
                    UserName = "TestUserName",
                    CreatedAt = DateTime.UtcNow,
                    Rating = 5
                },
                new Review()
                {
                    Id = 4,
                    ProteinPowderId = 1,
                    Comment = "Great taste and mixes well. Impact Whey is my go-to protein for post-workout recovery.",
                    UserName = "TestUserName",
                    CreatedAt = DateTime.UtcNow,
                    Rating = 5
                },
                new Review()
                {
                    Id = 5,
                    ProteinPowderId = 2,
                    Comment = "Bulk Isolate Protein delivers excellent results. It's a bit pricey, but the quality is worth it.",
                    UserName = "TestUserName",
                    CreatedAt = DateTime.UtcNow,
                    Rating = 4.8
                },
                new Review()
                {
                    Id = 6,
                    ProteinPowderId = 3,
                    Comment = 
                        "As a vegan, I love ProteinWorks' Vegan Protein. Tastes great and meets my nutritional needs perfectly.",
                    UserName = "TestUserName",
                    CreatedAt = DateTime.UtcNow,
                    Rating = 4.9
                }
            };

            return reviews;
        }
    }
}
