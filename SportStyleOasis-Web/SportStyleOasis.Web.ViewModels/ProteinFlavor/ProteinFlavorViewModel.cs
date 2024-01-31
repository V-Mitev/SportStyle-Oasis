namespace SportStyleOasis.Web.ViewModels.ProteinFlavor
{
    using System.ComponentModel.DataAnnotations;
    using static SportStyleOasis.Common.EntityValidationConstants.ProteinFlavor;

    public class ProteinFlavorViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ProteinFlavorNameMaxLength)]
        public string FlavorName { get; set; } = null!;

        [Range(ProteinFlavorMinQuantity, ProteinFlavorMaxQuantity)]
        public int Quantity { get; set; }
    }
}
