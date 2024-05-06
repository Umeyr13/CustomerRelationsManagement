using Microsoft.AspNetCore.Mvc;

namespace CustomerRelationsManagement.ViewComponents
{
    public class _LayoutNavbarPartialViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
