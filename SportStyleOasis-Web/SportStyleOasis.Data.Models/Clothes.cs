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
            ClotheInventories = new HashSet<ClotheInventory>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ClothesNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(ClothesNameMaxLength)]
        public string Color { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public ClothesBrands ClothesBrands { get; set; }

        public Gender ClothesForGender { get; set; }

        [Required]
        public string Image { get; set; } = null!;

        [Range(typeof(decimal), MinClothePrice, MaxClothePrice)]
        public decimal Price { get; set; }

        public TypeOfClothes TypeOfClothes { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<ClotheInventory> ClotheInventories { get; set; }
    }
}
