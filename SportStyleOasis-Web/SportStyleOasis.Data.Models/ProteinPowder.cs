﻿namespace SportStyleOasis.Data.Models
{
    using SportStyleOasis.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.ProteinPowder;

    public class ProteinPowder
    {
        public ProteinPowder()
        {
            Reviews = new HashSet<Review>();
            ProteinFlavors = new HashSet<ProteinFlavor>();
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(ProteinPowderNameMaxLength)]
        public string Name { get; set; } = null!;

        [Range(typeof(decimal), MinProteinPowderPrice, MaxProteinPowderPrice)]
        public decimal Price { get; set; }

        [Required]
        public string Image { get; set; } = null!;

        [Range(ProteinPowderTasteMinWeight, ProteinPowderTasteMaxWeight)]
        public int Weight { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public TypeOfProtein TypeOfProtein { get; set; }

        public ProteinPowderBrands ProteinPowderBrands { get; set; }

        public ICollection<ProteinFlavor> ProteinFlavors { get; set; }

        public ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
