namespace SportStyleOasis.Web.ViewModels.ClothReview
{
    using SportStyleOasis.Web.ViewModels.Clothes;
    using SportStyleOasis.Web.ViewModels.Review;

    public class ClothReviewViewModel
    {
        public ClothReviewViewModel()
        {
            Cloth = new ClothViewModel();
            Review = new ReviewViewModel();
        }

        public ClothViewModel Cloth { get; set; }
        public ReviewViewModel Review { get; set; }
    }
}
