using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseContexts;
using Models;
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
            var course = db.Courses.Find(id);
            return course;
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
    }
}
