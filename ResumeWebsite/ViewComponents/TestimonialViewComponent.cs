﻿using Microsoft.AspNetCore.Mvc;

namespace ResumeWebsite.ViewComponents
{
	public class TestimonialViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View("_Testimonial");
		}
	}
}