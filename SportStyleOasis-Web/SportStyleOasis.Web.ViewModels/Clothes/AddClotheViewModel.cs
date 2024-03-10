namespace SportStyleOasis.Web.ViewModels.Clothes
{
    using SportStyleOasis.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    using static SportStyleOasis.Common.EntityValidationConstants.Clothes;
    using static SportStyleOasis.Common.EntityValidationConstants.ClothInventory;

    public class AddClotheViewModel
    {
        public AddClotheViewModel()
        {
            SizesAndQuantities = new Dictionary<ClothesSize, int>(); 
        }

        [Required]
        [StringLength(ClothesNameMaxLength, MinimumLength = ClothesNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(ClothesNameMaxLength, MinimumLength = MinColorLength)]
        public string Color { get; set; } = null!;

        [Required]
        public string Image { get; set; } = null!;

        [Range(typeof(decimal), MinClothePrice, MaxClothePrice)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Range(AvailableQuantityMinValue, AvailableQuantityMaxValue)]
        public int AvailableQuantity { get; set; }

        public ClothesBrands? ClothesBrands { get; set; }

        public Gender? ClothesForGender { get; set; }

        public TypeOfClothes? TypeOfClothes { get; set; }

        public Dictionary<ClothesSize, int> SizesAndQuantities { get; set; }
    }
}
