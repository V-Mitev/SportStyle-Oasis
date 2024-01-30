namespace SportStyleOasis.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SportStyleOasis.Services.Interfces;
    using static Common.NotificationMessagesConstant;

    public class UserController : BaseAdminController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await userService.GetAllUsersAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string userId, string userFullName)
        {
            try
            {
                await userService.DeleteUserByIdAsync(userId);

                TempData[SuccessMessage] = $"Successfully deleted user: {userFullName}";

                return Ok();
            }
            catch (Exception)
            {
                return GeneralError();
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
