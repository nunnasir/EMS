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


    }
}