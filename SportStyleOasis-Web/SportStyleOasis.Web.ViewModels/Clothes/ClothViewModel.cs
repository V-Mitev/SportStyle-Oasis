namespace SportStyleOasis.Web.ViewModels.Clothes
{
    using SportStyleOasis.Web.ViewModels.ClothInventory;

    public class ClothViewModel : UpdateGarmentViewModel
    {
        public ClothViewModel()
        {
            ClothInventory = new HashSet<ClothInventoryViewModel>();
        }

        public ICollection<ClothInventoryViewModel> ClothInventory { get; set; }
    }
}
