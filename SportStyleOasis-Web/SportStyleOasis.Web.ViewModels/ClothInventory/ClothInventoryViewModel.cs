namespace SportStyleOasis.Web.ViewModels.ClothInventory
{
    using SportStyleOasis.Data.Models.Enums;

    public class ClothInventoryViewModel
    {
        public ClothesSize? ClothesSize { get; set; }

        public int AvailableQuantity { get; set; }
    }
}
