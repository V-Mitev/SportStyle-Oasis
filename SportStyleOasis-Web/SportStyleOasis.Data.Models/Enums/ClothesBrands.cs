namespace SportStyleOasis.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum ClothesBrands
    {
        Nike = 0, 
        Puma = 1,
        [Display(Name ="My protein")]
        MyProtein = 2,
        [Display(Name ="Under Armour")]
        UnderArmour = 3,
        Adidas = 4,
    }
}
