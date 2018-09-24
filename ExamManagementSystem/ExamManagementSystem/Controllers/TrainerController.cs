using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models.ViewModels;

namespace ExamManagementSystem.Controllers
{
    public class TrainerController : Controller
    {
        TrainerManager _trainerManager = new TrainerManager();

        // GET: Trainer
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //Load Trainer Entry Form
        public ActionResult Entry()
        {
            var model = new TrainerEntryVm();
            model.OrganizationList = GetOrganizationList();
            model.CountryList = GetCountryList();

            return View(model);
        }





        //Select Organization By DropDOwn
        private List<SelectListItem> GetOrganizationList()
        {
            return _trainerManager.GetAllOrganization()
                .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }).ToList();
        }

        //Select COuntry By DropDOwn
        private List<SelectListItem> GetCountryList()
        {
            return _trainerManager.GetAllCountries()
                .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }).ToList();
        }


        //Get Courses BY Organization
        public JsonResult GetCourseByOrganizationId(int id)
        {
            if (id > 0)
            {
                var dataList = _trainerManager.GetCourseByOrganizationId(id);
                return Json(dataList);
            }

            return null;
        }

        //Get Batch BY Course
        public JsonResult GetBatchByCourseId(int id)
        {
            if (id > 0)
            {
                var dataList = _trainerManager.GetBatchByCourseId(id);
                return Json(dataList);
            }

            return null;
        }

        //Get City BY Country
        public JsonResult GetCitiesByCountry(int id)
        {
            if (id > 0)
            {
                var dataList = _trainerManager.GetCitiesByCountry(id);
                return Json(dataList);
            }

            return null;
        }





    }
}