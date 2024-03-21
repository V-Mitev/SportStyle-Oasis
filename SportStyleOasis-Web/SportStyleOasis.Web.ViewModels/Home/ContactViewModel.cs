namespace SportStyleOasis.Web.ViewModels.Home
{
    using System.ComponentModel.DataAnnotations;
    using static SportStyleOasis.Common.GeneralApplicationConstants;

    public class ContactViewModel
    {
        [Required]
        [StringLength(FullNameMaxLenght, MinimumLength = FullNameMinLenght)]
        public string FullName { get; set; } = null!;

        [Required]
        [StringLength(SubjectMaxLenght, MinimumLength = SubjectMinLenght)]
        public string Subject { get; set; } = null!;

        [Required]
        [MinLength(MessageMinLength)]
        public string Message { get; set; } = null!;
    }
}
