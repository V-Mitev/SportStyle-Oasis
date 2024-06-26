﻿namespace SportStyleOasis.Services.Interfces
{
    using SportStyleOasis.Data.Models;
    using SportStyleOasis.Web.ViewModels.ProteinFlavor;

    public interface IFlavorService
    {
        public Task AddFlavorAsync(ProteinFlavorViewModel flavor, int id);

        public Task<bool> IsFlavorAlreadyAdded(int roteinPowderId, string flavorName);

        public Task<ICollection<ProteinFlavorViewModel>> AllProteinFlavorsAsync(int proteinPowderId);

        public Task EditFlavor(ICollection<ProteinFlavorViewModel> model, int proteinPowderId);

        Task<ProteinFlavor> GetProteinFlavorAsync(int proteinId, string proteinFlavor);

        Task DeleteProteinFlavorByIdAsync(int proteinFlavorId);
    }
}
