namespace SportStyleOasis.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Sidio.Sitemap.AspNetCore;
    using Sidio.Sitemap.Core;

    public class SitemapController : Controller
    {
        [Route("sitemap.xml")]
        public IActionResult SitemapHome()
        {
            var sitemap = new Sitemap();
            sitemap.Add(new SitemapNode(Url.Action("Index", "Home"), DateTime.UtcNow, ChangeFrequency.Yearly, priority:1));
            sitemap.Add(new SitemapNode(Url.Action("All", "Clothes"), DateTime.UtcNow, ChangeFrequency.Monthly, priority:1));

            return new SitemapResult(sitemap);
        }
    }
}
