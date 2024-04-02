namespace SportStyleOasis.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum TypeOfProtein
    {
        [Display(Name = "Whey Protein")]
        WheyProtein = 0,
        [Display(Name = "Vegan Protein")]
        VeganProtein = 1,
        [Display(Name = "Isolate Protein")]
        IsolateProtein = 2
    }
}
