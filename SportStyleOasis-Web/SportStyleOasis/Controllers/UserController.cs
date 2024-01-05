namespace SportStyleOasis.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SportStyleOasis.Data.Models;
    using SportStyleOasis.Web.ViewModels.User;

    public class UserController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserStore<ApplicationUser> userStore;

        public UserController(
            SignInManager<ApplicationUser> signInManager, 
            UserManager<ApplicationUser> userManager, 
            IUserStore<ApplicationUser> userStore)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.userStore = userStore;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ApplicationUser user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            await userManager.SetEmailAsync(user, model.Email);
            await userManager.SetPhoneNumberAsync(user, model.PhoneNumber);
            await userManager.SetUserNameAsync(user, model.Email);

            ShoppingCart shoppingCart = new ShoppingCart()
            {
                ApplicationUser = user,
                UserId = user.Id
            };

            user.ShoppingCart = shoppingCart;

            IdentityResult result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model);
            }

            await signInManager.SignInAsync(user, isPersistent: false);

            return RedirectToAction("Index", "Home");
        }
    }
}
