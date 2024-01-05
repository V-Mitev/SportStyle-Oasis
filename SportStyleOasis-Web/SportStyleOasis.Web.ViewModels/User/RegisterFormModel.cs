namespace SportStyleOasis.Web.ViewModels.User
{
    using System.ComponentModel.DataAnnotations;
    using static SportStyleOasis.Common.EntityValidationConstants.ApplicationUser;

    public class RegisterFormModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(PasswordMaxLenght, MinimumLength = PasswordMinLength,
                      ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = null!;

        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        [StringLength(PhoneNumberMaxLenght, MinimumLength = PhoneNumberMinLenght)]
        public string PhoneNumber { get; set; } = null!;
    }
}
