using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseContexts;
using Models;
using Models.SearchCriteria;
using Models.ViewModels;

namespace Repository
{
    public class CourseRepository
    {
        ExamManagementDbContext db = new ExamManagementDbContext();
        
        public bool Add(Course course)
        {
            db.Courses.Add(course);
            return db.SaveChanges() > 0;
        }

        public List<Organization> GetAll()
        {
            List<Organization> organization = db.Organizations.ToList();
            return organization;
        }

        public Course GetById(int id)
        {
            //var course = db.Courses.Find(id);
            //DOing Eagger Loading By Include
            var crs = db.Courses.Where(c => c.Id == id).Include(c => c.Organization).FirstOrDefault();
            //return course;
            return crs;
        }


        public bool Update(Course course)
        {
            db.Courses.Attach(course);
            db.Entry(course).State = EntityState.Modified;

            return db.SaveChanges() > 0;
        }

        public bool Deleted(int id)
        {
            Course course = new Course();
            course = db.Courses.Where(c => c.Id == id).FirstOrDefault();
            course.IsDeleted = true;

            return Update(course);
        }

        public List<Course> GetAllCourseInfo()
        {
            var course = db.Courses.Where(c => c.IsDeleted == false).ToList();
            return course;
        }

        public List<Course> GetCourseBySearch(CourseSearchCriteria criteria)
        {
            IQueryable<Course> courses = db.Courses.Where(c => c.IsDeleted == false).AsQueryable();

            if (!string.IsNullOrEmpty(criteria.Name))
            {
                courses = courses.Where(c => c.Name.ToLower().Contains(criteria.Name.ToLower()));
            }


            if (!string.IsNullOrEmpty(criteria.Code))
            {
                courses = courses.Where(c => c.Code.ToLower().Contains(criteria.Code.ToLower()));
            }

            if (!string.IsNullOrEmpty(criteria.Outline))
            {
                courses = courses.Where(c => c.Outline.ToLower().Contains(criteria.Outline.ToLower()));
            }

            if (!string.IsNullOrEmpty(criteria.Outline))
            {
                courses = courses.Where(c => c.Outline.ToLower().Contains(criteria.Outline.ToLower()));
            }

            if (criteria.CreditForm > 0 && criteria.CreditTo > 0)
            {
                courses = courses.Where(c => c.Credit >= criteria.CreditForm && c.Credit <= criteria.CreditTo);
            }

            if (criteria.OrganizationId > 0)
            {
                courses = courses.Where(c =>
                    c.OrganizationId.ToString().ToLower().Contains(criteria.OrganizationId.ToString().ToLower()));
            }

            return courses.ToList();
        }
    }
}
