using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseContexts;
using Models;
using Models.SearchCriteria;

namespace Repository
{
    public class OrganizationRepository
    {
        ExamManagementDbContext db = new ExamManagementDbContext();

        public List<Organization> GetOrganizationBySearch(OrganizationSearchCriteria criteria)
        {
            List<Organization> listorg = db.Organizations.ToList();

            IQueryable<Organization> organizations = db.Organizations.Where(org => org.IsDeleted == false).Include(org => org.Courses).AsQueryable();

            if (!string.IsNullOrEmpty(criteria.Name))
            {
                organizations = organizations.Where(org => org.Name.ToLower().Contains(criteria.Name.ToLower()));
            }

            if (!string.IsNullOrEmpty(criteria.Code))
            {
                organizations = organizations.Where(org => org.Code.ToLower().Contains(criteria.Code.ToLower()));
            }

            if (!string.IsNullOrEmpty(criteria.Address))
            {
                organizations = organizations.Where(org => org.Address.ToLower().Contains(criteria.Address.ToLower()));
            }

            if (!string.IsNullOrEmpty(criteria.ContactNo))
            {
                organizations = organizations.Where(org => org.ContactNo.ToLower().Contains(criteria.ContactNo.ToLower()));
            }

            return organizations.ToList();
        }

        public bool Add(Organization organization)
        {
            db.Organizations.Add(organization);
            return db.SaveChanges() > 0;
        }
    }
}
