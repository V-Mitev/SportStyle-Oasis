namespace SportStyleOasis.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SendGrid;
    using SendGrid.Helpers.Mail;
    using SportStyleOasis.Web.Infrastructure.Extensions;
    using SportStyleOasis.Web.ViewModels.Home;
    using static Common.GeneralApplicationConstants;
    using static SportStyleOasis.Common.NotificationMessagesConstant;

    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;

        public HomeController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IActionResult Index()
        {
            if (User.IsAdmin())
            {
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }

            return View();
        }

        public IActionResult Indexx()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400 || statusCode == 404)
            {
                return View("Error404");
            }

            if (statusCode == 401)
            {
                return View("Error401");
            }

            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Contact()
        {
            var model = new ContactViewModel();

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Contact(ContactViewModel model)
        {
            var email = User?.Identity?.Name;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (email == null)
            {
                return GeneralError();
            }

            try
            {
                await SendMail(email, model);

                return RedirectToAction("Contact", "Home");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        private async Task SendMail(string email, ContactViewModel model)
        {
            var adminEmail = configuration["SendGridApiKey:email"];
            var apiKey = configuration["SendGridApiKey:apiKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress($"{email}", $"{model.FullName}");
            var subject = $"{model.Subject}";
            var to = new EmailAddress($"{adminEmail}", "Vladimir Mitev");
            var plainTextContent = $"{model.Message}";
            var htmlContent = $"<strong>{model.Message}</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            await client.SendEmailAsync(msg);
        }

        private IActionResult GeneralError()
        {
            TempData[ErrorMessage] =
                "Unexpected error occurred! Please try again later or contact administrator";

            return RedirectToAction("Index", "Home");
        }
    }
}