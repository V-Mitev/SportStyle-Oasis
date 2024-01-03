namespace SportStyleOasis.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ShoppingCart
    {
        public ShoppingCart()
        {
            Clothes = new HashSet<Clothes>();
            ProteinPowders = new HashSet<ProteinPowder>();
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public Guid UserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; } = null!;

        public decimal TotalPrice { get; set; }

        public ICollection<Clothes> Clothes { get; set; }

        public ICollection<ProteinPowder> ProteinPowders { get; set; }
    }
}
