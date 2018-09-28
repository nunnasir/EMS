using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using BLL;
using Models;
using Models.SearchCriteria;
using Models.ViewModels;

namespace ExamManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        CourseManager _courseManager = new CourseManager();


        //INdex with Search Course
        public ActionResult Index(CourseSearchCriteria model)
        {
            var courses = _courseManager.GetCourseBySearch(model);
            
            if (courses == null)
            {
                courses = new List<Course>();
            }

            model.OrganizationListItem = GetOrganizationList();

            model.Course = courses;
            return View(model);
        }

        //Get Organization on COurse Entry
        public ActionResult CourseEntry()
        {
            var model = new CourseEntryVm();
            model.OrganizationListItem = GetOrganizationList();
            
            return View(model);
        }

        //Save New Course
        [HttpPost]
        public ActionResult CourseEntry(CourseEntryVm model)
        {
            if (ModelState.IsValid)
            {
                var course = Mapper.Map<Course>(model);
                
                bool isAdded = _courseManager.Add(course);
                
                if (isAdded)
                {
                    return RedirectToAction("CourseInformation", new {course.Id });
                }

            }

            return View();
        }

        //Edit Course
        public ActionResult CourseInformation(int id)
        {
            Course course = new Course();

            if (id > 0)
            {
                course =  _courseManager.GetById(id);
                var model = Mapper.Map<CourseEntryVm>(course);

                model.OrganizationListItem = GetOrganizationList();

                return View(model);
            }

            return View();
        }

        //Update Course
        [HttpPost]
        public ActionResult CourseInformation(CourseEntryVm model)
        {
            if (ModelState.IsValid)
            {
                var course = Mapper.Map<Course>(model);
                bool isUpdate = _courseManager.Update(course);
                if (isUpdate)
                {
                    return RedirectToAction("index");
                }
                model.OrganizationListItem = GetOrganizationList();
            }

            return View();
        }


        //Delete Course
        public ActionResult Delete(int id)
        {

            if (id > 0)
            {
                bool isDeleted = _courseManager.Deleted(id);
                if (isDeleted)
                {
                    //return View("Index");
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }

            return View("Index");
        }


        //View Course
        public ActionResult Details(int id)
        {
            Course course = new Course();

            if (id > 0)
            {
                course = _courseManager.GetById(id);
                var model = Mapper.Map<CourseEntryVm>(course);

                model.OrganizationListItem = GetOrganizationList();

                return View(model);
            }

            return View();
        }

        //Search Course


        //Select DropDOwn Method
        private List<SelectListItem> GetOrganizationList()
        {
             return _courseManager.GetAll()
                .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }).ToList();
        }




        //Get Course Code
        public JsonResult MakeCourseCode(int id)
        {
            var data = _courseManager.MakeCourseCode(id);
            //return Json(data);
            return Json(data.Count);
        }


    }
}