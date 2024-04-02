namespace SportStyleOasis.Controllers
{
    using Griesoft.AspNetCore.ReCaptcha;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.WebUtilities;
    using SportStyleOasis.Data.Models;
    using SportStyleOasis.Web.ViewModels.User;
    using System.Net;
    using System.Net.Mail;
    using System.Text;
    using System.Text.Encodings.Web;
    using static SportStyleOasis.Common.NotificationMessagesConstant;

    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;

        public UserController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.configuration = configuration;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateRecaptcha(Action = "submit")]
        public async Task<IActionResult> Register(RegisterFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var isEmailAlreadyExists = await userManager.FindByEmailAsync(model.Email);

            if (isEmailAlreadyExists != null)
            {
                TempData[ErrorMessage] = "This email already exists, please try again with another email";

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
            try
            {
                // Generate email confirmation token
                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));

                // Construct the callback URL for email confirmation
                var confirmationLink = Url.Action("ConfirmEmail", "User", new { userId = user.Id, code = token }, Request.Scheme);

                // Send the confirmation email
                SendEmail(model.Email, "Confirm your email",
               $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(confirmationLink!)}'>clicking here</a>.");
            }
            catch (Exception)
            {
                return GeneralError();
            }

            // Redirect to a page indicating that the user should check their email for activation
            return RedirectToAction("RegisterConfirmation");
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
                TempData[ErrorMessage] = "Email or password are invalid";

                return View(model);
            }

            if (user.EmailConfirmed == false)
            {
                TempData["WarningMessage"] =
                    "Account not activated. Please check your email for the activation link.";

                return View(model);
            }

            var isPasswordMatch =
                await signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (!isPasswordMatch.Succeeded)
            {
                TempData[ErrorMessage] = "Email or password are invalid";

                return View(model);
            }

            var result =
                await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (!result.Succeeded)
            {
                TempData[ErrorMessage] =
                    "There was an error while loggin in! Please try again latter or cantact an administrator.";

                return View(model);
            }

            return Redirect(model.ReturnUrl ?? "/Home/Index");
        }

        [HttpGet]
        public IActionResult RegisterConfirmation()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return GeneralError();
            }

            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                TempData[ErrorMessage] = "Unable to load user with this data.";
                return RedirectToAction("Index", "Home");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await userManager.ConfirmEmailAsync(user, code);

            var model = new ConfirmEmailViewModel()
            {
                Message = result.Succeeded ? "Thank you for confirming your email." : "Error confirming your email."
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            var model = new ForgotPasswordViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                TempData[ErrorMessage] = "Please check your email. User not found with this email.";
                return View(model);
            }

            if (!await userManager.IsEmailConfirmedAsync(user))
            {
                TempData[WarningMessage] = "User email is not confirmed yet. Please complete your email first.";
                return View(model);
            }

            try
            {
                var token = await userManager.GeneratePasswordResetTokenAsync(user);
                token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));

                var callbackUrl = Url.Action("ResetPassword", "User", new { email = model.Email, token = token }, Request.Scheme);
                model.IsEmailSend = SendEmail(model.Email, "Reset Password",
                    $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl!)}'>clicking here</a>.");

                return View(model);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public IActionResult ResetPassword(string email, string token)
        {
            var model = new ResetPasswordViewModel()
            {
                Email = email,
                Token = token
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                TempData[ErrorMessage] = "Please check your email. User not found with this email.";
                return View(model);
            }

            if (string.IsNullOrEmpty(model.Token))
            {
                return GeneralError();
            }

            try
            {
                var token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(model.Token));
                var result = await userManager.ResetPasswordAsync(user, token, model.Password);

                if (!result.Succeeded)
                {
                    return GeneralError();
                }

                model.IsPasswordReset = result.Succeeded;

                return View(model);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        private bool SendEmail(string email, string subject, string confirmLink)
        {
            var myEmail = configuration["SendGridApiKey:email"];
            var gmailPasscode = configuration["GoogleGmailPassword:googleGmailPassCode"];

            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(myEmail);
                    mail.To.Add(email);
                    mail.Subject = subject;
                    mail.IsBodyHtml = true;
                    mail.Body = confirmLink;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = false;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Credentials = new NetworkCredential($"{myEmail}", $"{gmailPasscode}");

                        smtp.Send(mail);
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private IActionResult GeneralError()
        {
            TempData[ErrorMessage] =
                "Unexpected error occurred! Please try again later or contact administrator";

            return RedirectToAction("Index", "Home");
        }
    }
}
