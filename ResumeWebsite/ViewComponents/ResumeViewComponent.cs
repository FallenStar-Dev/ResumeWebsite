using Microsoft.AspNetCore.Mvc;

namespace ResumeWebsite.ViewComponents
{
	public class ResumeViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View("_Resume");
		}
	}
}