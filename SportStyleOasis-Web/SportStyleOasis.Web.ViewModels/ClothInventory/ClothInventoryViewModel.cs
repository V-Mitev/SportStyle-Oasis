namespace SportStyleOasis.Web.ViewModels.ClothInventory
{
    using SportStyleOasis.Data.Models.Enums;

    public class ClothInventoryViewModel
    {
        public  int  Id { get; set; }

        public ClothesSize? ClothesSize { get; set; }

        public int AvailableQuantity { get; set; }
    }
}
