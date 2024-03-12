namespace SportStyleOasis.Web.ViewModels.ClothInventory
{
    using SportStyleOasis.Data.Models.Enums;
    using SportStyleOasis.Web.ViewModels.Clothes;

    public class ClothInventoryViewModel
    {
        public ClothInventoryViewModel()
        {
            ClothForShoppingCart = new ClothForShoppingCartViewModel();    
        }

        public  int  Id { get; set; }

        public ClothForShoppingCartViewModel? ClothForShoppingCart { get; set; }

        public ClothesSize? ClothesSize { get; set; }

        public int AvailableQuantity { get; set; }
    }
}
