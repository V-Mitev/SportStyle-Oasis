namespace SportStyleOasis.Web.ViewModels.Clothes
{
    using SportStyleOasis.Data.Models.Enums;
    using System.ComponentModel;
    using static SportStyleOasis.Common.GeneralApplicationConstants;

    public class AllClothesQueryModel
    {
        public AllClothesQueryModel()
        {
            CurrentPage = DefaultPage;
            ClothesPerPage = EntitiesPerPage;

            Clothes = new HashSet<AllClothesViewModel>();

            Genders = new HashSet<Gender>();
            TypeOfClothes = new HashSet<TypeOfClothes>();
            ClothesBrands = new HashSet<ClothesBrands>();
        }

        [DisplayName("Gender")]
        public Gender? Gender { get; set; }

        [DisplayName("Type of clothe")]
        public TypeOfClothes? TypeOfClothe { get; set; }

        [DisplayName("Clothes brand")]
        public ClothesBrands? ClotheBrand { get; set; }

        [DisplayName("Search by word")]
        public string? SearchString { get; set; }

        public int CurrentPage { get; set; }

        [DisplayName("Clothes Per Page")]
        public int ClothesPerPage { get; set; }

        public int TotalClothes { get; set; }

        public IEnumerable<Gender> Genders { get; set; }

        public IEnumerable<TypeOfClothes> TypeOfClothes { get; set; }

        public IEnumerable<ClothesBrands> ClothesBrands { get; set; }

        public ICollection<AllClothesViewModel> Clothes { get; set; }
    }
}
