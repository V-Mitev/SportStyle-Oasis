namespace SportStyleOasis.Web.ViewModels.Clothes
{
    public class AllClothesModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Color { get; set; } = null!;

        public string Image { get; set; } = null!;

        public string ClothType { get; set; } = null!;

        public string ClothSize { get; set; } = null!;

        public decimal Price { get; set; }
    }
}
