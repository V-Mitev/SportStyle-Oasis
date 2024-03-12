namespace SportStyleOasis.Web.ViewModels.ClothInventory
{
    public class ClothOrderQuantityViewModel
    {
        public int Id { get; set; }

        public int ShoppingCartId { get; set; }

        public int ClothId { get; set; }

        public string Size { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
