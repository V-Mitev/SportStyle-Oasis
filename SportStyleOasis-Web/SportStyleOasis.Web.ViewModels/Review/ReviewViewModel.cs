namespace SportStyleOasis.Web.ViewModels.Review
{
    using System.ComponentModel.DataAnnotations;

    public class ReviewViewModel
    {
        public int? Id { get; set; }

        public string UserName { get; set; } = null!;

        [Required]
        public string Comment { get; set; } = null!;

        public double Rating { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
