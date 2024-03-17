namespace SportStyleOasis.Services.Data.Models.ProteinPowder
{
    using SportStyleOasis.Data.Models.Enums;
    using SportStyleOasis.Web.ViewModels.ProteinPowder;
    using System.ComponentModel;
    using static SportStyleOasis.Common.GeneralApplicationConstants;

    public class AllProteinsQueryModel
    {
        public AllProteinsQueryModel()
        {
            CurrentPage = DefaultPage;
            ProteinsPerPage = EntitiesPerPage;

            ProteinPowders = new HashSet<AllProteinPowderViewModel>();
            ProteinBrands = new HashSet<ProteinPowderBrands>();
        }

        [DisplayName("Protein powder brands")]
        public ProteinPowderBrands? ProteinPowderBrand { get; set; }

        [DisplayName("Search by word")]
        public string? SearchString { get; set; }

        public int CurrentPage { get; set; }

        [DisplayName("Number of proteins per page")]
        public int ProteinsPerPage { get; set; }

        public int TotalProteins { get; set; }

        public ICollection<ProteinPowderBrands> ProteinBrands { get; set; }

        public ICollection<AllProteinPowderViewModel> ProteinPowders { get; set; }
    }
}
