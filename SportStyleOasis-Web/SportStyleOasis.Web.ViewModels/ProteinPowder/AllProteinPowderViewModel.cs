namespace SportStyleOasis.Web.ViewModels.ProteinPowder
{
    public class AllProteinPowderViewModel
    {
        public AllProteinPowderViewModel()
        {
            ProteinFlavor = new HashSet<string>();
        }

        public string Name { get; set; } = null!;

        public string Brand { get; set; } = null!;

        public ICollection<string> ProteinFlavor { get; set; }

        public int Weight { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; } = null!;

        public string ProteinType { get; set; } = null!;
    }
}
