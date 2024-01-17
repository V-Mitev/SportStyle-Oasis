namespace SportStyleOasis.Web.ViewModels.ProteinPowder
{
    using SportStyleOasis.Data.Models.Enums;
    using SportStyleOasis.Web.ViewModels.ProteinFlavor;

    public class AllProteinPowderViewModel
    {
        public AllProteinPowderViewModel()
        {
            ProteinFlavors = new HashSet<ProteinFlavorViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string Image { get; set; } = null!;

        public DateTime TimeForAddFlavor { get; set; }

        public ProteinPowderBrands? ProteinPowderBrand { get; set; }

        public ICollection<ProteinFlavorViewModel> ProteinFlavors { get; set; }
    }
}
