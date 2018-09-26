using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
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

            var datalist =  organizations.ToList();

            foreach (var organization in datalist)
            {
                organization.Courses = organization.Courses.Where(c => c.IsDeleted == false).ToList();
            }

            return datalist;

        }

        //Add Organization
        public bool Add(Organization organization)
        {
            db.Organizations.Add(organization);
            return db.SaveChanges() > 0;
        }

        //Find Organization By Id
        public Organization GetById(int id)
        {
            var organization = db.Organizations.Where(c => c.Id == id).FirstOrDefault();

            db.Entry(organization).Collection(c => c.Courses).Query().Where(x => x.IsDeleted == false).Load();
            db.Entry(organization).Collection(c => c.Trainers).Query().Where(x => x.IsDeleted == false).Load();
            db.Entry(organization).Collection(c => c.Participants).Query().Where(x => x.IsDeleted == false).Load();
            

            return organization;
        }


        //Update Organization
        public bool Update(Organization organization)
        {
            db.Entry(organization).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        //Delete Organization
        public bool Delete(int id)
        {
            Organization organization = new Organization();
            //organization = db.Organizations.Where(c => c.Id == id).FirstOrDefault();
            organization = db.Organizations.Where(c => c.Id == id).Where(c => c.Courses.Count < 1).FirstOrDefault();

            if (organization != null)
            {
                organization.IsDeleted = true;
                return Update(organization);
            }

            return false;
        }
    }
}
