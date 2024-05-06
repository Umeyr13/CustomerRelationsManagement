using Microsoft.AspNetCore.Mvc;

namespace CustomerRelationsManagement.Controllers
{
    public class DefaultLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
