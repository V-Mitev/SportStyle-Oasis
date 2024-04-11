namespace SportStyleOasis.Web.ViewModels.Clothes
{
    public class ClothForShoppingCartViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Image { get; set; } = null!;

        public decimal Price { get; set; }

        public string Color { get; set; } = null!;

        public string Size { get; set; } = null!;

        public int? OrderedQuantity { get; set; }

        public int AvailableQuantity { get; set; }

        public int ClothInventoryId { get; set; }
    }
}
