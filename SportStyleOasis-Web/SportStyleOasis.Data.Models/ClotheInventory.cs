namespace SportStyleOasis.Data.Models
{
    using SportStyleOasis.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static SportStyleOasis.Common.EntityValidationConstants.ClothInventory;

    public class ClotheInventory
    {
        public ClotheInventory()
        {
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        [Key]
        public int Id { get; set; }

        public ClothesSize? ClothesSize { get; set; }

        [Range(AvailableQuantityMinValue, AvailableQuantityMaxValue)]
        public int AvailableQuantity { get; set; }

        [ForeignKey(nameof(Clothe))]
        public int ClothId { get; set; }
        public Clothes Clothe { get; set; } = null!;

        public ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
