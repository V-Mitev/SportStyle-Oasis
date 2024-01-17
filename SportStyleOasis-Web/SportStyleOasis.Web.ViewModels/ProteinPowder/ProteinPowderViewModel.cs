namespace SportStyleOasis.Web.ViewModels.ProteinPowder
{
    using SportStyleOasis.Data.Models.Enums;
    using SportStyleOasis.Web.ViewModels.ProteinFlavor;

    public class ProteinPowderViewModel : AllProteinPowderViewModel
    {
        public string Description { get; set; } = null!;

        public int Weight { get; set; }

        public TypeOfProtein? TypeOfProtein { get; set; }

    }
}
