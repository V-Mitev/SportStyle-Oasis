namespace SportStyleOasis.Web.ViewModels.Review
{
    using System.ComponentModel.DataAnnotations;

    public class ReviewViewModel
    {
        public int Id { get; set; }

        public string UserName { get; set; } = null!;

        public string? Comment { get; set; }

        public double Rating { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
