using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BLL;
using Models;

namespace ExamManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        CourseManager _courseManager = new CourseManager();

        //For Get Data
        [HttpGet]
        public ActionResult CourseEntry()
        {
            Course course = new Course();

            GetDrodownSelectItemList(course);

            return View(course);

        }

        //For Save Data
        [HttpPost]
        public ActionResult CourseEntry(Course course)
        {
            if (ModelState.IsValid)
            {
                bool isAdded = _courseManager.Add(course);
                
                //_courseManager.Add(course);


                GetDrodownSelectItemList(course);
                
                if (isAdded)
                {
                    //return RedirectToAction("CourseInformation", new RouteValueDictionary(new {Controller = "Course", Action = "CourseInformation", course.Id}));
                    return RedirectToAction("CourseInformation",new RouteValueDictionary(new {course.Id}));
                }
                
            }

            return View();
        }

        //For Edit
        [HttpGet]
        public ActionResult CourseInformation(int id)
        {
            Course course = new Course();

            if (id > 0)
            {
                course = _courseManager.GetById(id);
            }

            GetDrodownSelectItemList(course);


            return View(course);
        }

        //for update
        public ActionResult CourseInformation(Course course)
        {
            if (ModelState.IsValid)
            {
                _courseManager.Update(course);

                GetDrodownSelectItemList(course);

                return View(course);
            }

            return View();
        }




        //Select DropDOwn Method
        private void GetDrodownSelectItemList(Course course)
        {
            List<Organization> organizations = _courseManager.GetAll();

            List<SelectListItem> selectListItems = new List<SelectListItem>();

            foreach (var organizationData in organizations)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = organizationData.Name;
                selectListItem.Value = organizationData.Id.ToString();

                selectListItems.Add(selectListItem);
            }

            course.OrganizationListItem = selectListItems;
        }
    }
}