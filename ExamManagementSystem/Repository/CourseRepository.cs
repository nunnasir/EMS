using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseContexts;
using Models;

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
            Course course = db.Courses.Find(id);
            return course;
        }


        public bool Update(Course course)
        {
            db.Courses.Attach(course);
            db.Entry(course).State = EntityState.Modified;

            return db.SaveChanges() > 0;
        }
    }
}
