namespace SportStyleOasis.Web.ViewModels.ProteinFlavor
{
    using SportStyleOasis.Web.ViewModels.ProteinPowder;
    using System.ComponentModel.DataAnnotations;
    using static SportStyleOasis.Common.EntityValidationConstants.ProteinFlavor;

    public class ProteinFlavorViewModel
    {
        public ProteinFlavorViewModel()
        {
            ProteinPowder = new ProteinPowderViewModel();    
        }

        public int Id { get; set; }

        public ProteinPowderViewModel ProteinPowder { get; set; }

        [Required]
        [MaxLength(ProteinFlavorNameMaxLength)]
        public string FlavorName { get; set; } = null!;

        [Range(ProteinFlavorMinQuantity, ProteinFlavorMaxQuantity)]
        public int Quantity { get; set; }

        public int ProteinPowderId { get; set; }
    }
}
