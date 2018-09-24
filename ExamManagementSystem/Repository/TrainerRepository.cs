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
    public class TrainerRepository
    {
        ExamManagementDbContext db = new ExamManagementDbContext();
        
        //Get All Organization
        public List<Organization> GetAllOrgnization()
        {
            List<Organization> organizations = db.Organizations.Where(c => c.IsDeleted == false).ToList();
            return organizations;
        }


        //Get Courses Againts Organization
        public List<Course> GetCourseByOrganizationId(int id)
        {
            var course = db.Courses.Where(c => c.OrganizationId == id && c.IsDeleted == false).ToList();
            return course;
        }

        //Add Trainer
        public bool Add(Trainer trainer)
        {
            db.Trainers.Add(trainer);

            return db.SaveChanges() > 0;
        }

        //Get All Trainers
        public List<Trainer> GetBatchBySearch(TrainerSearchCriteria criteria)
        {
            IQueryable<Trainer> trainers = db.Trainers.Where(c => c.IsDeleted == false).AsQueryable();

            //if (!string.IsNullOrEmpty(criteria.Name))
            //{
            //    trainers = trainers.Where(c => c.Name.ToLower().Contains(criteria.Name.ToLower()));
            //}

            return trainers.ToList();
        }


        //Get Trainer By Id
        public Trainer GetById(int id)
        {
            var data = db.Trainers.Where(c => c.Id == id).FirstOrDefault();
            return data;
        }

        //Update Trainer
        public bool Update(Trainer trainer)
        {
            db.Entry(trainer).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        //Delete Trainer
        public bool Delete(int id)
        {
            Trainer trainer = new Trainer();
            trainer = db.Trainers.Where(c => c.Id == id).FirstOrDefault();

            if (trainer != null)
            {
                trainer.IsDeleted = true;
                return Update(trainer);
            }

            return false;
        }

        //Get Batch Againts Course
        public List<Batch> GetBatchByCourseId(int id)
        {
            var batch = db.Batches.Where(c => c.CourseId == id && c.IsDeleted == false).ToList();
            return batch;
        }

        //Get All Countries
        public List<Country> GetAllCountries()
        {
            List<Country> countries = db.Countries.ToList();
            return countries;
        }

        //Get city Againts COuntries
        public List<City> GetCitiesByCountry(int id)
        {
            var cities = db.Cities.Where(c => c.CountryId == id).ToList();
            return cities;
        }




    }
}
