﻿namespace SportStyleOasis.Web.ViewModels.User
{
    using System.ComponentModel.DataAnnotations;

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "The email of forgotten account.")]
        public string Email { get; set; } = null!;

        public bool IsEmailSend { get; set; }
    }
}
