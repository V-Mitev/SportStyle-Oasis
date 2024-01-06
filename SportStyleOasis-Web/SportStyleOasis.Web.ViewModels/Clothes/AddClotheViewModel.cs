namespace SportStyleOasis.Web.ViewModels.Clothes
{
    using SportStyleOasis.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    using static SportStyleOasis.Common.EntityValidationConstants.Clothes;

    public class AddClotheViewModel
    {
        [Required]
        [MaxLength(ClothesNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(ClothesNameMaxLength)]
        public string Color { get; set; } = null!;

        [Required]
        public string Image { get; set; } = null!;

        [Range(typeof(decimal), MinClothePrice, MaxClothePrice)]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Range(ClotheMinAvailableQuantity, ClotheMaxAvailableQuantity)]
        public int AvailableQuantity { get; set; }

        public ClothesBrands ClothesBrands { get; set; }

        public Gender ClothesForGender { get; set; }

        public TypeOfClothes TypeOfClothes { get; set; }

        public ClothesSize ClotheSize { get; set; }
    }
}
