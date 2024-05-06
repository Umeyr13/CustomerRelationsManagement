using Microsoft.AspNetCore.Mvc;

namespace CustomerRelationsManagement.ViewComponents
{
    public class _LayoutSideBarPartialViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
