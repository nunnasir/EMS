using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BLL;
using Models;
using Models.SearchCriteria;
using Models.ViewModels;

namespace ExamManagementSystem.Controllers
{
    public class TrainerController : Controller
    {
        TrainerManager _trainerManager = new TrainerManager();

        // GET: Trainer
        public ActionResult Index(TrainerSearchCriteria model)
        {
            model.OrganizationList = GetOrganizationList();
            model.CountryList = GetCountryList();

            var trainers = _trainerManager.GetTrainerBySearch(model);
            if (trainers == null)
            {
                trainers = new List<Trainer>();
            }

            model.TrainerList = trainers;
            
            return View(model);
        }


        //Load Trainer Entry Form
        public ActionResult Entry()
        {
            var model = new TrainerEntryVm();
            model.OrganizationList = GetOrganizationList();
            model.CountryList = GetCountryList();

            return View(model);
        }

        [HttpPost]
        //public ActionResult Entry(TrainerEntryVm model, HttpPostedFileBase Image)
        public ActionResult Entry(TrainerEntryVm model)
        {
            if (ModelState.IsValid)
            {
                //if (Image != null && Image.ContentLength > 0)
                //{
                //    model.Image = new byte[Image.ContentLength];
                //    Image.InputStream.Read(model.Image, 0, Image.ContentLength);
                //}

                var trainer = Mapper.Map<Trainer>(model);
                
                bool isAdded = _trainerManager.Add(trainer);
                if (isAdded)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Entry");
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
                return Json(dataList.Select(c => new {Id = c.Id, Name = c.Name}));
            }

            return null;
        }


    }
}