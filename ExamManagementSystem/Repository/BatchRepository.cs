using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseContexts;
using Models;
using Models.SearchCriteria;

namespace Repository
{
    public class BatchRepository
    {
        ExamManagementDbContext db = new ExamManagementDbContext();

        public List<Organization> GetAllOrgnization()
        {
            List<Organization> organizations = db.Organizations.Where(c => c.IsDeleted == false).ToList();
            return organizations;
        }

        public List<Course> GetCourseByOrganizationId(int id)
        {
            var course = db.Courses.Where(c => c.OrganizationId == id && c.IsDeleted == false).ToList();
            return course;
        }

        public bool Add(Batch batch)
        {
            db.Batches.Add(batch);

            return db.SaveChanges() > 0;
        }

        public List<Batch> GetBatchBySearch(BatchSearchCriteria model)
        {
            //IQueryable<Batch> batches = db.Batches.AsQueryable();
            IQueryable<Batch> batches = db.Batches.AsQueryable();



            //if (model.CourseId != 0)
            //{
            //    batches = batches.Where(c =>
            //        c.CourseId.ToString().ToLower().Contains(model.CourseId.ToString().ToLower()));
            //}

            //if (!string.IsNullOrEmpty(model.StartDate.ToString()))
            //{
            //    batches = batches.Where(c => c.StartDate >= model.StartDate);
            //}

            return batches.ToList();
        }
    }



}
