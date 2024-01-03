namespace SportStyleOasis.Services.Interfces
{
    using SportStyleOasis.Web.ViewModels.Clothes;

    public interface IClothesService
    {
        public Task<ICollection<AllClothesModel>> AllAsync();
    }
}
