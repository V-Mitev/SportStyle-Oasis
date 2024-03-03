namespace SportStyleOasis.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ShoppingCart
    {
        public ShoppingCart()
        {
            ClotheInventories = new HashSet<ClotheInventory>();
            ProteinFlavors = new HashSet<ProteinFlavor>();
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public Guid UserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; } = null!;

        public ICollection<ClotheInventory> ClotheInventories { get; set; }

        public ICollection<ProteinFlavor> ProteinFlavors { get; set; }
    }
}
