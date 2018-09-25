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

            IQueryable<Batch> batches = db.Batches.Where(c => c.IsDeleted == false).AsQueryable();

            //if (!string.IsNullOrEmpty(model.Course.Name))
            //{
            //    batches = batches.Where(c => c.Course.Name.ToLower().Contains(model.Course.Name.ToLower()));
            //}

            if (!string.IsNullOrEmpty(model.Name))
            {
                batches = batches.Where(
                    c => c.Name.ToString().ToLower().Contains(model.Name.ToString().ToLower()));
            }

            if (!string.IsNullOrEmpty(model.StartDate.ToString()))
            {
                batches = batches.Where(c => c.StartDate >= model.StartDate);
            }

            //if (!string.IsNullOrEmpty(model.EndDate.ToString()))
            //{
            //    batches = batches.Where(c => c.EndDate <= model.EndDate);
            //}
            

            return batches.ToList();
        }

        public List<Batch> GetBatchNoByCourseId(int id)
        {
            var data = db.Batches.Where(c => c.CourseId == id);
            
            return data.ToList();
        }

        //Get Batch By Id
        public Batch GetById(int id)
        {
            var data = db.Batches.Where(c => c.Id == id).FirstOrDefault();
            return data;
        }


        //Update Batches
        public bool Update(Batch batch)
        {
            db.Entry(batch).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        //Delete Batch
        public bool Delete(int id)
        {
            Batch batch = new Batch();
            batch = db.Batches.Where(c => c.Id == id).Where(cs => cs.Participants.Count == 0 && cs.Trainers.Count == 0).FirstOrDefault();

            if (batch != null)
            {
                batch.IsDeleted = true;
                return Update(batch);
            }

            return false;
        }
    }



}
