using System;
using System.Collections.Generic;
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
    public class ParticipantController : Controller
    {
        ParticipantManager _participantManager = new ParticipantManager();


        //Index and Search
        public ActionResult Index(ParticipantSearchCriteria model)
        {
            model.OrganizationList = GetOrganizationList();
            model.CountryList = GetCountryList();

            var participants = _participantManager.GetTrainerBySearch(model);
            if (participants == null)
            {
                participants = new List<Participant>();
            }

            model.ParticipantList = participants;

            return View(model);
        }


        //Load Participant Entry Form
        public ActionResult Entry()
        {
            var model = new ParticipantEntryVm();
            model.OrganizationList = GetOrganizationList();
            model.CountryList = GetCountryList();

            return View(model);
        }

        //Save Participant
        [HttpPost]
        public ActionResult Entry(ParticipantEntryVm model)
        {
            if (ModelState.IsValid)
            {
                var participant = Mapper.Map<Participant>(model);

                bool isAdded = _participantManager.Add(participant);
                if (isAdded)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Entry");
        }


        //Edit Participant
        public ActionResult Edit(int id)
        {
            var participant = new Participant();
            if (id > 0)
            {
                participant = _participantManager.GetById(id);

                var model = Mapper.Map<ParticipantEntryVm>(participant);

                model.OrganizationList = GetOrganizationList();
                model.CountryList = GetCountryList();

                return View(model);
            }

            return View();
        }


        //Update Participant
        [HttpPost]
        public ActionResult Edit(ParticipantEntryVm model)
        {
            if (ModelState.IsValid)
            {
                var trainer = Mapper.Map<Participant>(model);
                bool isUpdate = _participantManager.Update(trainer);

                if (isUpdate)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }


        //Delete Participant
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                bool isDeleted = _participantManager.Delete(id);
                if (isDeleted)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }


        //Details Participant
        public ActionResult Details(int id)
        {
            if (id > 0)
            {
                var participant = _participantManager.GetById(id);

                var model = Mapper.Map<ParticipantEntryVm>(participant);

                return View(model);
            }

            return View();
        }



        //Select Organization By DropDOwn
        private List<SelectListItem> GetOrganizationList()
        {
            return _participantManager.GetAllOrganization()
                .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }).ToList();
        }

        //Select COuntry By DropDOwn
        private List<SelectListItem> GetCountryList()
        {
            return _participantManager.GetAllCountries()
                .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }).ToList();
        }


        //Get City BY Country
        public JsonResult GetCitiesByCountry(int id)
        {
            if (id > 0)
            {
                var dataList = _participantManager.GetCitiesByCountry(id);
                return Json(dataList);
            }

            return null;
        }


        //Get Courses BY Organization
        public JsonResult GetCourseByOrganizationId(int id)
        {
            if (id > 0)
            {
                var dataList = _participantManager.GetCourseByOrganizationId(id);
                return Json(dataList.Select(c => new { Id = c.Id, Name = c.Name }));
            }

            return null;
        }

        //Get Batch BY Course
        public JsonResult GetBatchByCourseId(int id)
        {
            if (id > 0)
            {
                var dataList = _participantManager.GetBatchByCourseId(id);
                return Json(dataList.Select(c => new { Id = c.Id, Name = c.Name }));
            }

            return null;
        }


        //Make Participant Code
        public JsonResult MakeParticipantRegNo(int id)
        {
            if (id > 0)
            {
                var dataList = _participantManager.MakeParticipantRegNo(id);
                return Json(dataList.Count);
            }

            return null;
        }


    }
}