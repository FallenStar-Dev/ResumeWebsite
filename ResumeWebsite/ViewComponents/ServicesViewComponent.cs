using Microsoft.AspNetCore.Mvc;

namespace ResumeWebsite.ViewComponents
{
	public class ServicesViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View("_Services");
		}
	}
}
