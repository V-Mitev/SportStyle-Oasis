﻿namespace SportStyleOasis.Web.ViewModels.ShoppingCart
{
    using SportStyleOasis.Web.ViewModels.Clothes;
    using SportStyleOasis.Web.ViewModels.ProteinPowder;

    public class ShoppingCartViewModel
    {
        public ShoppingCartViewModel()
        {
            Clothes = new HashSet<ClothForShoppingCartViewModel>();
            ProteinPowders = new HashSet<ProteinPowderForShoppingCartViewModel>();
        }

        public int Id { get; set; }

        public ICollection<ClothForShoppingCartViewModel> Clothes { get; set; }

        public ICollection<ProteinPowderForShoppingCartViewModel> ProteinPowders { get; set; }
    }
}
