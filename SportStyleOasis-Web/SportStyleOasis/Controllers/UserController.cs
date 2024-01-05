namespace SportStyleOasis.Controllers
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SportStyleOasis.Data.Models;
    using SportStyleOasis.Web.ViewModels.User;

    public class UserController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public UserController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
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

        [HttpGet]
        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            LoginFormModel model = new LoginFormModel()
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                //To add notification
                ModelState.AddModelError(string.Empty, "Email or password are invalid");

                return View(model);
            }

            var isPasswordMatch = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (!isPasswordMatch.Succeeded)
            {
                //To add notification
                ModelState.AddModelError(string.Empty, "Email or password are invalid");

                return View(model);
            }

            var result =
                await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (!result.Succeeded)
            {
                //To add notification message

                return View(model);
            }

            return Redirect(model.ReturnUrl ?? "/Home/Index");
        }
    }
}
