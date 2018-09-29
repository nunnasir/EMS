using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.SearchCriteria;
using Repository;

namespace BLL
{
    public class ExamManager
    {
        ExamRepository _examRepository = new ExamRepository();

        //Add Exam
        public bool Add(Exam exam)
        {
            return _examRepository.Add(exam);
        }

        //Get By Id
        public Exam GetById(int id)
        {
            return _examRepository.GetById(id);
        }

        //Update Exam
        public bool Update(Exam exam)
        {
            return _examRepository.Update(exam);
        }

        //Delete Exam
        public bool Deleted(int id)
        {
            return _examRepository.Deleted(id);
        }

        //Get Organization
        public List<Organization> GetAllOrganizations()
        {
            return _examRepository.GetAllOrganizations();
        }

        //Get Course
        public List<Course> GetAllCourses(int id)
        {
            return _examRepository.GetAllCourses(id);
        }

        //Get Exam Type
        public List<ExamType> GetAllExamTypes()
        {
            return _examRepository.GetAllExamTypes();
        }

        //Search Exam
        public List<Exam> GetExamBySearch(ExamSearchCriteria criteria)
        {
            List<Exam> exams = _examRepository.GetExamBySearch(criteria);
            return exams;
        }

        //Make Code
        public List<Exam> MakeExamCode(int id)
        {
            return _examRepository.MakeExamCode(id);
        }

    }
}
