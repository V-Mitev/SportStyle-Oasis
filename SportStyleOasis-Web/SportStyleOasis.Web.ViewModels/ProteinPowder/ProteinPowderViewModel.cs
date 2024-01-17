namespace SportStyleOasis.Web.ViewModels.ProteinPowder
{
    using SportStyleOasis.Data.Models.Enums;
    using SportStyleOasis.Web.ViewModels.Review;

    public class ProteinPowderViewModel : AllProteinPowderViewModel
    {
        public ProteinPowderViewModel()
        {
            Reviews = new HashSet<ReviewViewModel>();        
        }

        public string Description { get; set; } = null!;

        public int Weight { get; set; }

        public TypeOfProtein? TypeOfProtein { get; set; }

        public ICollection<ReviewViewModel> Reviews { get; set; }
    }
}
