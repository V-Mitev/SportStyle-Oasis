namespace SportStyleOasis.Web.ViewModels.Clothes
{
    using SportStyleOasis.Web.ViewModels.ClothInventory;
    using SportStyleOasis.Web.ViewModels.Review;

    public class ClothViewModel : UpdateClothViewModel
    {
        public ClothViewModel()
        {
            ClothInventory = new HashSet<ClothInventoryViewModel>();
            Reviews = new HashSet<ReviewViewModel>();
        }

        public ICollection<ClothInventoryViewModel> ClothInventory { get; set; }

        public ICollection<ReviewViewModel> Reviews { get; set; }
    }
}
