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
    public class OrganizationController : Controller
    {
        OrganizationManager _organizationManager = new OrganizationManager();

        public ActionResult Index(OrganizationSearchCriteria model)
        {
            var organizations = _organizationManager.GetOrganizationBySearch(model);

            if (organizations == null)
            {
                organizations = new List<Organization>();
            }

            model.OrganizationLists = organizations;

            return View(model);
        }

        public ActionResult Entry()
        {
            return View();
        }

        //Save Organization
        [HttpPost]
        public ActionResult Entry(OrganizationEntryVm model)
        {
            if (ModelState.IsValid)
            {
                var organization = Mapper.Map<Organization>(model);
                bool isAdded = _organizationManager.Add(organization);
                if (isAdded)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        //Edit Organization
        public ActionResult Edit(int id)
        {
            //Organization organization = new Organization();
            var organization = new Organization();

            if (id > 0)
            {
                organization = _organizationManager.GetById(id);
                
                var model = Mapper.Map<OrganizationEntryVm>(organization);

                return View(model);
            }

            return View();
        }


        //Update Organization
        [HttpPost]
        public ActionResult Edit(OrganizationEntryVm model)
        {
            if (ModelState.IsValid) 
            {
                var organization = Mapper.Map<Organization>(model);
                bool isUpdate = _organizationManager.Update(organization);
                if (isUpdate)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        //Delete Organization
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                bool isDeleted = _organizationManager.Delete(id);
                if (isDeleted)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        //Organization Details
        public ActionResult Details(int id)
        {
            var organization = _organizationManager.GetById(id);

            var org = Mapper.Map<OrganizationEntryVm>(organization);

            return View(org);
        }

        //Course Edit
        public ActionResult CourseEdit(int id)
        {
            return RedirectToAction("CourseInformation", "Course");
        }




        //Get Organization Code
        public JsonResult MakeOrganizationCode()
        {
            var data = _organizationManager.MakeOrganizationCode();
            //return Json(data);
            return Json(data.Count);
        }

    }
}