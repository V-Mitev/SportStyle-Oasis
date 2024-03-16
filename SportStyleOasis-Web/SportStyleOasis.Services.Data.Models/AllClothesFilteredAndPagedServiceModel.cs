namespace SportStyleOasis.Services.Data.Models
{
    using SportStyleOasis.Web.ViewModels.Clothes;

    public class AllClothesFilteredAndPagedServiceModel
    {
        public AllClothesFilteredAndPagedServiceModel()
        {
            Clothes = new HashSet<AllClothesViewModel>();
        }

        public int TotalClothesCount { get; set; }

        public ICollection<AllClothesViewModel> Clothes { get; set; }
    }
}
