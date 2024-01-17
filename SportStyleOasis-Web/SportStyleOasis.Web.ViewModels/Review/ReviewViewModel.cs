namespace SportStyleOasis.Web.ViewModels.Review
{
    public class ReviewViewModel
    {
        public string UserName { get; set; } = null!;

        public string? Comment { get; set; }

        public double Rating { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
