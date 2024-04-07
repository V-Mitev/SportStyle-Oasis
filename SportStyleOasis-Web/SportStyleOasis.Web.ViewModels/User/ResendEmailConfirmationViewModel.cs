namespace SportStyleOasis.Web.ViewModels.User
{
    using System.ComponentModel.DataAnnotations;

    public class ResendEmailConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        public bool IsSuccessfulResendEmail { get; set; }
    }
}
