namespace SportStyleOasis.Web.ViewModels.ProteinPowder
{
    public class ProteinPowderForShoppingCartViewModel : ProteinPowderViewModel
    {
        public string FlavorName { get; set; } = null!;

        public int? OrderedQuantity { get; set; }

        public int AvailableQuantity { get; set; }

        public int ProteinOrderedQuantityId { get; set; }
    }
}
