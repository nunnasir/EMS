using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.SearchCriteria;
using Models.ViewModels;
using Repository;

namespace BLL
{
    public class CourseManager
    {
        CourseRepository _courseRepository = new CourseRepository();

        public bool Add(Course course)
        {
            //Logic Here
            return _courseRepository.Add(course);
        }

        public List<Organization> GetAll()
        {
            return _courseRepository.GetAll();
        }

        public Course GetById(int id)
        {
            return _courseRepository.GetById(id);
        }

        public bool Update(Course course)
        {
            return _courseRepository.Update(course);
        }

        public List<Course> GetAllCourseInfo()
        {
            return _courseRepository.GetAllCourseInfo();
        }

        public bool Deleted(int id)
        {
            return _courseRepository.Deleted(id);
        }

        public List<Course> GetCourseBySearch(CourseSearchCriteria criteria)
        {
            List<Course> courses = _courseRepository.GetCourseBySearch(criteria);
            return courses;
        }
    }
}
