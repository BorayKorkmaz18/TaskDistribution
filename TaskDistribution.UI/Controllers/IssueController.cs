using Microsoft.AspNetCore.Mvc;

namespace TaskDistribution.UI.Controllers
{
    public class IssueController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
