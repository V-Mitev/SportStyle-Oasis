namespace SportStyleOasis.Web.ViewModels.Clothes
{
    using SportStyleOasis.Data.Models.Enums;

    public class UpdateGarmentViewModel : AllClothesModel
    {
        public string Description { get; set; } = null!;

        public Gender GarmentForGender { get; set; }

        public ClothesBrands GarmentBrand { get; set; }

        public TypeOfClothes GarmentType { get; set; }
    }
}
