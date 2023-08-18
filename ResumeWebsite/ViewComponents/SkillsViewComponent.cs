using Microsoft.AspNetCore.Mvc;

using ResumeWebsite.Models;
using ResumeWebsite.Tools;

using System.Data.SqlTypes;

namespace ResumeWebsite.ViewComponents
{
    public class SkillsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var sql = new SqlClass();
            var querySkills = @"SELECT Title,Proficiency,SortID 
								FROM   PersonalDb.dbo.Skills 
								order by SortID";
            var skillList = sql.SelectDb<SkillsModel>(querySkills).ToList();
            return View("_Skills", skillList);
        }
    }
}
