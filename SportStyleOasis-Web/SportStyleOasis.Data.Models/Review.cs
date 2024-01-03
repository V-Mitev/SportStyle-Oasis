namespace SportStyleOasis.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Review
    {
        [Key]
        public int Id { get; set; }

        public string? Comments { get; set; }

        public int Rating { get; set; }

        [ForeignKey(nameof(Clothes))]
        public int? ClothesId { get; set; }

        public Clothes? Clothes { get; set; }

        [ForeignKey(nameof(ProteinPowder))]
        public int? ProteinPowderId { get; set; }

        public ProteinPowder? ProteinPowder { get; set; }
    }
}
