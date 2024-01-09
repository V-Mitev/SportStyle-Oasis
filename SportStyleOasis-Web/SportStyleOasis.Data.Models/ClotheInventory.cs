namespace SportStyleOasis.Data.Models
{
    using SportStyleOasis.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static SportStyleOasis.Common.EntityValidationConstants.Clothes;

    public class ClotheInventory
    {
        [Key]
        public int Id { get; set; }

        public ClothesSize? ClothesSize { get; set; }

        [Range(ClotheMinAvailableQuantity, ClotheMaxAvailableQuantity)]
        public int AvailableQuantity { get; set; }

        [ForeignKey(nameof(Clothes))]
        public int ClothId { get; set; }
        public Clothes Clothes { get; set; } = null!;
    }
}
