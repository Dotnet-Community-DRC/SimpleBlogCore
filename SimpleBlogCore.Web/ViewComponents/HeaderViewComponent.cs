using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SimpleBlogCore.Web.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.Factory.StartNew(() => { return View(); });
        }
    }
}