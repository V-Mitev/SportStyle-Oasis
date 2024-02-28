namespace SportStyleOasis.Web.ViewModels.Clothes
{
    using SportStyleOasis.Data.Models.Enums;

    public class ClothForShoppingCartViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Image { get; set; } = null!;

        public decimal Price { get; set; }

        public string Color { get; set; } = null!;

        public ClothesSize Size { get; set; }
    }
}
