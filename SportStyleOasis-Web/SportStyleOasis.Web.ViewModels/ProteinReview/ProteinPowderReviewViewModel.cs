namespace SportStyleOasis.Web.ViewModels.ProteinReview
{
    using SportStyleOasis.Web.ViewModels.ProteinPowder;
    using SportStyleOasis.Web.ViewModels.Review;

    public class ProteinPowderReviewViewModel
    {
        public ProteinPowderReviewViewModel()
        {
            ProteinPowder = new ProteinPowderViewModel();
            Review = new ReviewViewModel();
        }

        public ProteinPowderViewModel ProteinPowder { get; set; }

        public ReviewViewModel Review { get; set; }
    }
}
