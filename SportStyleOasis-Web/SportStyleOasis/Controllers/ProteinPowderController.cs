namespace SportStyleOasis.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SportStyleOasis.Services.Interfces;

    public class ProteinPowderController : Controller
    {
        private readonly IProteinPowderService proteinPowderService;

        public ProteinPowderController(IProteinPowderService proteinPowderService)
        {
            this.proteinPowderService = proteinPowderService;
        }

        public async Task<IActionResult> All()
        {
            var proteinPowders = await proteinPowderService.AllAsync();

            return View(proteinPowders);
        }
    }
}
