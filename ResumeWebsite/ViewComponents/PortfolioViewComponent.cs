using Microsoft.AspNetCore.Mvc;

namespace ResumeWebsite.ViewComponents
{
	public class PortfolioViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View("_Portfolio");
		}
	}
}
