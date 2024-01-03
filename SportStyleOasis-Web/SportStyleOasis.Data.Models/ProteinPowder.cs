namespace SportStyleOasis.Data.Models
{
    using SportStyleOasis.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.ProteinPowder;

    public class ProteinPowder
    {
        public ProteinPowder()
        {
            Reviews = new HashSet<Review>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(ProteinPowderNameMaxLength)]
        public string Name { get; set; } = null!;

        [Range(typeof(decimal), MinProteinPowderPrice, MaxProteinPowderPrice)]
        public decimal Price { get; set; }

        public int QuantityOrder { get; set; }

        public int AvailabeQuantity { get; set; }

        [Range(typeof(double), MinProteinPowderWeight, MaxProteinPowderWeight)]
        public double Weight { get; set; }

        public TypeOfProtein TypeOfProtein { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
