namespace SportStyleOasis.Web.ViewModels.ProteinPowder
{
    using SportStyleOasis.Data.Models.Enums;
    using SportStyleOasis.Web.ViewModels.ProteinFlavor;
    using System.ComponentModel.DataAnnotations;
    using static SportStyleOasis.Common.EntityValidationConstants.ProteinPowder;

    public class AddProteinPowderViewModel
    {
        public AddProteinPowderViewModel()
        {
            ProteinFlavors = new HashSet<ProteinFlavorViewModel>();    
        }

        [StringLength(ProteinPowderNameMaxLength, MinimumLength = ProteinPowderNameMinLength)]
        public string Name { get; set; } = null!;

        [Range(typeof(decimal), MinProteinPowderPrice, MaxProteinPowderPrice)]
        public decimal Price { get; set; }

        [Required]
        public string Image { get; set; } = null!;

        [Range(ProteinPowderTasteMinWeight, ProteinPowderTasteMaxWeight)]
        public int Weight { get; set; }

        [Required]
        [StringLength(ProteinPowderDescriptionMaxLength, MinimumLength = ProteinPowderDescriptionMinLength)]
        public string Description { get; set; } = null!;

        public TypeOfProtein? TypeOfProtein { get; set; }

        public ProteinPowderBrands? ProteinPowderBrands { get; set; }

        public ICollection<ProteinFlavorViewModel> ProteinFlavors { get; set; }
    }
}
