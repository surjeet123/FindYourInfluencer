using Microsoft.AspNetCore.Mvc;

namespace FindYourInfluencer.Areas.Influencer.Controllers
{
    [Area("Influencer")]
    public class InfluencerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
