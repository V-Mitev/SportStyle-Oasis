namespace SportStyleOasis.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static SportStyleOasis.Common.EntityValidationConstants.ProteinFlavor;

    public class ProteinFlavor
    {
        public ProteinFlavor()
        {
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ProteinFlavorNameMaxLength)]
        public string FlavorName { get; set; } = null!;

        [Range(ProteinFlavorMinQuantity, ProteinFlavorMaxQuantity)]
        public int Quantity { get; set; }

        [ForeignKey(nameof(Protein))]
        public int ProteinId { get; set; }
        public ProteinPowder Protein { get; set; } = null!;

        public ProteinOrderQuantity? ProteinOrderQuantity { get; set; }

        public ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
