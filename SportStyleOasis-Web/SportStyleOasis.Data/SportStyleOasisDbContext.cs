namespace SportStyleOasis.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using SportStyleOasis.Data.Configuration;
    using SportStyleOasis.Data.Models;

    public class SportStyleOasisDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public SportStyleOasisDbContext(DbContextOptions<SportStyleOasisDbContext> options)
            : base(options)
        {}

        public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;

        public DbSet<Clothes> Clothes { get; set; } = null!;

        public DbSet<ProteinPowder> ProteinPowder { get; set;} = null!;

        public DbSet<Review> Review { get; set; } = null!;

        public DbSet<ShoppingCart> ShoppingCarts { get; set; } = null!;

        public DbSet<ClotheInventory> ClotheInventories { get; set; } = null!;

        public DbSet<ProteinFlavor> ProteinFlavor { get; set; } = null!;

        public DbSet<ClotheOrderQuantity> ClotheOrderQuantities { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration<Clothes>(new ClothesConfiguration());

            builder.ApplyConfiguration<ClotheInventory>(new ClotheInventoryConfiguration());

            builder.ApplyConfiguration<ProteinPowder>(new ProteinPowderConfiguration());

            builder.ApplyConfiguration<ProteinFlavor>(new ProteinFlavorConfiguration());

            builder.ApplyConfiguration<Review>(new ReviewConfiguration());

            base.OnModelCreating(builder);
        }
    }
}