namespace SportStyleOasis.Web.ViewModels.ClothInventory
{
    public class EditClothInventoryViewModel : ClothInventoryViewModel
    {
        public EditClothInventoryViewModel()
        {
            ClotheQuantityAndSize = new Dictionary<string, int>();
        }

        public Dictionary<string, int> ClotheQuantityAndSize { get; set; }
    }
}
