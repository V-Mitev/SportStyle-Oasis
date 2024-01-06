namespace SportStyleOasis.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static SportStyleOasis.Common.EntityValidationConstants.ProteinFlavor;

    public class ProteinFlavor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FlavorName { get; set; } = null!;

        [Range(ProteinFlavorMinQuantity, ProteinFlavorMaxQuantity)]
        public int Quantity { get; set; }

        [ForeignKey(nameof(Protein))]
        public int ProteinId { get; set; }
        public ProteinPowder Protein { get; set; } = null!;
    }
}
