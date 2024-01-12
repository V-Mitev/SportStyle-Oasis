namespace SportStyleOasis
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using SportStyleOasis.Data;
    using SportStyleOasis.Data.Models;
    using SportStyleOasis.Services.Interfces;
    using SportStyleOasis.Web.Infrastructure.ModelBinders;
    using static SportStyleOasis.Web.Infrastructure.Extensions.WebApplicationBuilderExtensions;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<SportStyleOasisDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount =
                    builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
                options.Password.RequireLowercase =
                    builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
                options.Password.RequireUppercase =
                    builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
                options.Password.RequireNonAlphanumeric =
                    builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
                options.Password.RequiredLength =
                    builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
                options.Password.RequireDigit =
                    builder.Configuration.GetValue<bool>("Identity:Password:RequireDigit");

                //To add in production
                //options.Lockout.MaxFailedAccessAttempts = 
                //    builder.Configuration.GetValue<int>("Identity:Lockout:MaxFailedAccessAttempts");
                //options.Lockout.DefaultLockoutTimeSpan = 
                //    TimeSpan.FromMinutes(builder.Configuration.GetValue<int>("Identity:Lockout:DefaultLockoutTimeSpan"));
                //options.Lockout.AllowedForNewUsers = 
                //    builder.Configuration.GetValue<bool>("Identity:Lockout:AllowedForNewUsers");
            })
               .AddRoles<IdentityRole<Guid>>()
               .AddEntityFrameworkStores<SportStyleOasisDbContext>();

            builder.Services
                .AddControllersWithViews()
                .AddMvcOptions(options =>
                {
                    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
                });

            builder.Services.AddApplicationServices(typeof(IClothesService));

            builder.Services.AddRecaptchaService();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            builder.Services.ConfigureApplicationCookie(cfg =>
            {
                cfg.LoginPath = "/User/Login";
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error/500");
                app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}