using Microsoft.AspNetCore.Mvc;

namespace CustomerRelationsManagement.ViewComponents
{
    public class _LayoutHeaderPartialViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
