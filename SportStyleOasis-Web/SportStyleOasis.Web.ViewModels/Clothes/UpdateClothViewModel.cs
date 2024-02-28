namespace SportStyleOasis.Web.ViewModels.Clothes
{
    using SportStyleOasis.Data.Models.Enums;

    public class UpdateClothViewModel : AllClothesViewModel
    {
        public string Color { get; set; } = null!;

        public string Description { get; set; } = null!;

        public Gender ClothForGender { get; set; }

        public ClothesBrands ClothBrand { get; set; }

        public TypeOfClothes ClothType { get; set; }
    }
}
