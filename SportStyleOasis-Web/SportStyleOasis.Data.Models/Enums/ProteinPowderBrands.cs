namespace SportStyleOasis.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum ProteinPowderBrands
    {
        Bulk = 0,
        [Display(Name = "Optimum Nutrition Gold")]
        OptimumNutritionGold = 1,
        Impact = 2,
        [Display(Name = "My Protein")]
        MyProtein = 3,
        Innermost = 4,
        [Display(Name = "Protein Works")]
        ProteinWorks = 5
    }
}
