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
    public class ExamController : Controller
    {
        ExamManager _examManager = new ExamManager();

        //Index with Search Exam
        public ActionResult Index(ExamSearchCriteria model)
        {
            var exams = _examManager.GetExamBySearch(model);

            if (exams == null)
            {
                exams = new List<Exam>();
            }

            model.OrganizationListItem = GetOrganizationList();
            model.ExamTypeListItem = GetAllExamTypes();
            
            model.Exams = exams;
            return View(model);
        }


        //Exam Entry Page
        public ActionResult Entry()
        {
            var model = new ExamEntryVm();
            model.OrganizationListItem = GetOrganizationList();
            model.ExamTypeListItem = GetAllExamTypes();

            return View(model);
        }


        //Save New Exam
        [HttpPost]
        public ActionResult Entry(ExamEntryVm model)
        {
            if (ModelState.IsValid)
            {
                var exam = Mapper.Map<Exam>(model);

                bool isAdded = _examManager.Add(exam);

                if (isAdded)
                {
                    return RedirectToAction("Index");
                }

            }

            return View();
        }


        //Edit Exam
        public ActionResult Edit(int id)
        {
            Exam exam = new Exam();

            if (id > 0)
            {
                exam = _examManager.GetById(id);
                var model = Mapper.Map<ExamEntryVm>(exam);

                model.OrganizationListItem = GetOrganizationList();
                model.ExamTypeListItem = GetAllExamTypes();

                return View(model);
            }

            return View();
        }



        //Update Exam
        [HttpPost]
        public ActionResult Edit(ExamEntryVm model)
        {
            if (ModelState.IsValid)
            {
                var exam = Mapper.Map<Exam>(model);
                bool isUpdate = _examManager.Update(exam);
                if (isUpdate)
                {
                    return RedirectToAction("index");
                }
                model.OrganizationListItem = GetOrganizationList();
            }

            return View();
        }



        //Delete Exam
        public ActionResult Delete(int id)
        {

            if (id > 0)
            {
                bool isDeleted = _examManager.Deleted(id);
                if (isDeleted)
                {
                    //return View("Index");
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }

            return View("Index");
        }


        //View Exam
        public ActionResult Details(int id)
        {
            Exam exam = new Exam();

            if (id > 0)
            {
                exam = _examManager.GetById(id);
                var model = Mapper.Map<ExamEntryVm>(exam);

                model.OrganizationListItem = GetOrganizationList();

                return View(model);
            }

            return View();
        }




        //Question Entry Page
        public ActionResult QuestionEntry()
        {
            var model = new Question();
            model.OrganizationListItem = GetOrganizationList();

            return View(model);
        }


        //Question Save
        [HttpPost]
        public ActionResult QuestionEntry(Question question)
        {
            if (ModelState.IsValid && question.QuestionOptionses != null && question.QuestionOptionses.Count > 0)
            {
                bool isAdded = _examManager.QuestionAdd(question);
                if (isAdded)
                {
                    return RedirectToAction("QuestionEntry");
                }
            }

            return View();
        }


        //Question Index with search
        public ActionResult QuestionIndex(QuestionSearchCriteria model)
        {
            var questions = _examManager.GetQuestionBySearch(model);

            if (questions == null)
            {
                questions = new List<Question>();
            }
            model.OrganizationListItem = GetOrganizationList();

            model.Questions = questions;

            return View(model);
        }

        //Question Details
        public ActionResult QuestionDetails(int id)
        {
            Question question = new Question();

            if (id > 0)
            {
                question = _examManager.GetQuestionById(id);

                return View(question);
            }

            return View();
        }



        //Select DOrganization
        private List<SelectListItem> GetOrganizationList()
        {
            return _examManager.GetAllOrganizations()
                .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }).ToList();
        }


        //Get Courses BY Organization
        public JsonResult GetCourseByOrganizationId(int id)
        {
            if (id > 0)
            {
                var dataList = _examManager.GetAllCourses(id);
                return Json(dataList.Select(c => new { Id = c.Id, Name = c.Name }));
            }

            return null;
        }


        //Select Exam Type
        private List<SelectListItem> GetAllExamTypes()
        {
            return _examManager.GetAllExamTypes()
                .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }).ToList();
        }

        //Select Exam Type
        public JsonResult GetExamByCourse(int id)
        {
            if (id > 0)
            {
                var dataList = _examManager.GetExamByCourse(id);
                return Json(dataList.Select(c => new { Id = c.Id, Name = c.Topic}));
            }

            return null;
        }


        //Get Exam Code
        public JsonResult MakeExamCode(int id)
        {
            var data = _examManager.MakeExamCode(id);
            //return Json(data);
            return Json(data.Count);
        }

        //Get Question Order
        public JsonResult MakeQuestionOrder(int id)
        {
            var data = _examManager.MakeQuestionOrder(id);
            //return Json(data);
            return Json(data.Count);
        }


    }
}