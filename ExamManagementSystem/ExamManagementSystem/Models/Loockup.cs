using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace ExamManagementSystem.Models
{
    public class Loockup
    {
        CourseManager _courseManager = new CourseManager();

        //List<SelectListItem> selectListItemss = _courseManager.GetAll()
        //    .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }).ToList();
    }
}