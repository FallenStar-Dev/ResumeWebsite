using Microsoft.AspNetCore.Mvc;

namespace ResumeWebsite.ViewComponents
{
	public class BlogViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View("_Blog");
		}
	}
}