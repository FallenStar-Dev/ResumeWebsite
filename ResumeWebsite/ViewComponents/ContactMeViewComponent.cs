using Microsoft.AspNetCore.Mvc;

using ResumeWebsite.Models;
using ResumeWebsite.Tools;

namespace ResumeWebsite.ViewComponents
{
	public class ContactMeViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var sql = new SqlClass();
			var queryAbout = @"select Email,Address,Phone 
								From PersonalDb.dbo.AboutMe";
			var about = sql.SelectDb<ContactMe>(queryAbout).First();
			return View("_ContactMe",about);
		}
	}
}