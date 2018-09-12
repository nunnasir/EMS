using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;

namespace ExamManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        CourseManager _courseManager = new CourseManager();

        [HttpGet]
        public ActionResult CourseEntry()
        {
            Course course = new Course();

            List<Organization> organizations = _courseManager.GetAll();

            List<SelectListItem> selectListItems = new List<SelectListItem>();

            foreach (var organizationData in organizations)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = organizationData.Name;
                selectListItem.Value = organizationData.Id.ToString();

                selectListItems.Add(selectListItem);
            }

            course.OrganizationListItem.AddRange(selectListItems);

            return View(course);

            //return View();
        }

        [HttpPost]
        public ActionResult CourseEntry(Course course)
        {
            if (ModelState.IsValid)
            {
                //bool isAdded = _courseManager.Add(course);

                _courseManager.Add(course);
                //var organization = _courseManager.GetAll();

                //if (isAdded)
                //{
                //    return View("CourseInformation");
                //}
            }

            return View();
        }


    }
}