namespace SportStyle_Oasis.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class SportStyleOasisDbContext : IdentityDbContext
    {
        public SportStyleOasisDbContext(DbContextOptions<SportStyleOasisDbContext> options) 
            : base(options)
        {
            
        }
    }
}
