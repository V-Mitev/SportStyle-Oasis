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
        }
    }
}
