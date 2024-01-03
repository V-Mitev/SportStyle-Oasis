namespace SportStyleOasis.Data.Models
{
    using SportStyleOasis.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    using static SportStyleOasis.Common.EntityValidationConstants.Clothes;

    public class Clothes
    {
        public Clothes()
        {
            Reviews = new HashSet<Review>();    
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ClothesNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(ClothesNameMaxLength)]
        public string Color { get; set; } = null!;

        public ClothesSize Size { get; set; }

        [Range(typeof(decimal), MinClothePrice, MaxClothePrice)]
        public decimal Price { get; set; }

        public int QuantityOrder { get; set; }

        public int AvailabeQuantity { get; set; }

        public TypeOfClothes TypeOfClothes { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
