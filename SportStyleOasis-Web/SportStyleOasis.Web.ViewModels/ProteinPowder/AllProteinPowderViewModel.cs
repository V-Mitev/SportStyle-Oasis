namespace SportStyleOasis.Web.ViewModels.ProteinPowder
{
    using SportStyleOasis.Data.Models.Enums;

    public class AllProteinPowderViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string Image { get; set; } = null!;

        public DateTime TimeForAddFlavor { get; set; }

        public ProteinPowderBrands? ProteinPowderBrand { get; set; }
    }
}
