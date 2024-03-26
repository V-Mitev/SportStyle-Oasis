namespace SportStyleOasis.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum TypeOfClothes
    {
        [Display(Name = "T-Shirt")]
        TShirt = 0,
        Tracksuit = 1,
        Bottom = 2,
        Sweatshirt = 3,
        [Display(Name = "Tank Top")]
        TankTop = 4,
        Shorts = 5,
        Top = 6,
        Socks = 7
    }
}
