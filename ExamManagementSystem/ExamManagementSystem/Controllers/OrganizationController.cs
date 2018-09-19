using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using Models.SearchCriteria;

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


    }
}