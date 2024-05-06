using Microsoft.AspNetCore.Mvc;

namespace CustomerRelationsManagement.ViewComponents
{
    public class _LayoutFooterPartialViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
