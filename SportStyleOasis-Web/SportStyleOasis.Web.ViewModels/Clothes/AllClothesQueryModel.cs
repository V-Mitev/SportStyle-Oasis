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
            ClothesBrands = new HashSet<ClothesBrands>();
        }

        [DisplayName("Clothes brand")]
        public ClothesBrands? ClotheBrand { get; set; }

        [DisplayName("Search by word")]
        public string? SearchString { get; set; }

        public int CurrentPage { get; set; }

        [DisplayName("Number of Clothes Per Page")]
        public int ClothesPerPage { get; set; }

        public int TotalClothes { get; set; }

        public ICollection<ClothesBrands> ClothesBrands { get; set; }

        public ICollection<AllClothesViewModel> Clothes { get; set; }
    }
}
