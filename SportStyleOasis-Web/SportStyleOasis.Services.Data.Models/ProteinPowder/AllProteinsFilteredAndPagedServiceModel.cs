namespace SportStyleOasis.Services.Data.Models.ProteinPowder
{
    using SportStyleOasis.Web.ViewModels.ProteinPowder;

    public class AllProteinsFilteredAndPagedServiceModel
    {
        public AllProteinsFilteredAndPagedServiceModel()
        {
            ProteinPowders = new HashSet<AllProteinPowderViewModel>();
        }

        public int TotalProteinsCount { get; set; }

        public ICollection<AllProteinPowderViewModel> ProteinPowders { get; set; }
    }
}
