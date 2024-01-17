namespace SportStyleOasis.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static SportStyleOasis.Common.EntityValidationConstants.Review;

    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; } = null!;

        public DateTime CreateAt { get; set; }

        public string? Comment { get; set; }

        [Range(typeof(double), RatingMinValue, RatingMaxValue)]
        public double Rating { get; set; }

        [ForeignKey(nameof(Clothes))]
        public int? ClothesId { get; set; }

        public Clothes? Clothes { get; set; }

        [ForeignKey(nameof(ProteinPowder))]
        public int? ProteinPowderId { get; set; }

        public ProteinPowder? ProteinPowder { get; set; }
    }
}
