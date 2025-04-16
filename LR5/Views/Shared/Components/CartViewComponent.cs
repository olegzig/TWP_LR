using Microsoft.AspNetCore.Mvc;

namespace LR5.Views.Shared.Components
{
    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
