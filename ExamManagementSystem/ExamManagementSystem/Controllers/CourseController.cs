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
using Models.ViewModels;

namespace ExamManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        CourseManager _courseManager = new CourseManager();

        public ActionResult Index()
        {
            var model = _courseManager.GetAllCourseInfo();
            return View(model);
        }

        //For Get Data
        public ActionResult CourseEntry()
        {
            var model = new CourseEntryVm();
            model.OrganizationListItem = GetOrganizationList();
            
            return View(model);
        }

        //For Save Data
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

        //For Edit
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

        //for update
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
            }

            return View("Index");
        }


        //Select DropDOwn Method
        private List<SelectListItem> GetOrganizationList()
        {
             return _courseManager.GetAll()
                .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }).ToList();
        }


        //Select DropDOwn Method
        //private void GetDrodownSelectItemList(Course course)
        //{
        //    List<Organization> organizations = _courseManager.GetAll();

        //    List<SelectListItem> selectListItems = new List<SelectListItem>();

            

        //    foreach (var organizationData in organizations)
        //    {
        //        SelectListItem selectListItem = new SelectListItem();
        //        selectListItem.Text = organizationData.Name;
        //        selectListItem.Value = organizationData.Id.ToString();

        //        selectListItems.Add(selectListItem);
        //    }

        //    course.OrganizationListItem = selectListItems;
        //}
    }
}