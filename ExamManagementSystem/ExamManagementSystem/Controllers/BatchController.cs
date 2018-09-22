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
    public class BatchController : Controller
    {
        BatchManager _batchManager = new BatchManager();

        // GET: Entry Batch
        public ActionResult Entry()
        {
            var model = new BatchEntryVm();
            model.OrganizationList = GetOrganizationList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Entry(BatchEntryVm model)
        {
            var batch = Mapper.Map<Batch>(model);
            bool isAdded = _batchManager.Add(batch);
            if (isAdded)
            {
                return RedirectToAction("Entry");
            }

            return View();
        }

        //Index and Batch Search
        public ActionResult Index(BatchSearchCriteria model)
        {
            var batch = _batchManager.GetBatchBySearch(model);
            


            if (batch == null)
            {
                batch = new List<Batch>();
            }


            model.ListOfBatch = batch;
            
            return View(model);
        }


        //Select Organization By DropDOwn
        private List<SelectListItem> GetOrganizationList()
        {
            return _batchManager.GetAllOrganization()
                .Select(c => new SelectListItem(){Value = c.Id.ToString(), Text = c.Name}).ToList();
        }


        //Get Courses BY Organization
        public JsonResult GetCourseByOrganizationId(int id)
        {
            if (id > 0)
            {
                var dataList = _batchManager.GetCourseByOrganizationId(id);
                return Json(dataList);
            }

            return null;
        }

    }
}