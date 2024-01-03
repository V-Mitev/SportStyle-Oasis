namespace SportStyleOasis.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using static SportStyleOasis.Common.EntityValidationConstants.ApplicationUser;

    public class ApplicationUser : IdentityUser<Guid>
    {
        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        public ShoppingCart ShoppingCart { get; set; } = null!;
    }
}