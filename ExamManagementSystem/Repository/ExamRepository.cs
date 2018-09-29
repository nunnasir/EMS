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
    public class ExamRepository
    {
        ExamManagementDbContext db = new ExamManagementDbContext();

        //Add Exam
        public bool Add(Exam exam)
        {
            db.Exams.Add(exam);
            return db.SaveChanges() > 0;
        }

        //Get By Id
        public Exam GetById(int id)
        {
            var exam = db.Exams.Where(c => c.Id == id).FirstOrDefault();
            return exam;
        }

        //Update Exam
        public bool Update(Exam exam)
        {
            db.Exams.Attach(exam);
            db.Entry(exam).State = EntityState.Modified;

            return db.SaveChanges() > 0;
        }

        //Delete Exam
        public bool Deleted(int id)
        {
            Exam exam = new Exam();
            exam = db.Exams.Where(c => c.Id == id).FirstOrDefault();
            exam.IsDeleted = true;

            return Update(exam);
        }

        //Get Organization List
        public List<Organization> GetAllOrganizations()
        {
            List<Organization> organization = db.Organizations.Where(c => c.IsDeleted == false).ToList();
            return organization;
        }

        //Get Courses
        public List<Course> GetAllCourses(int id)
        {
            var course = db.Courses.Where(c => c.IsDeleted == false && c.OrganizationId == id).ToList();
            return course;
        }

        //Get Exam Types
        public List<ExamType> GetAllExamTypes()
        {
            List<ExamType> examTypes = db.ExamTypes.ToList();
            return examTypes;
        }

        //Make Exam Code
        public List<Exam> MakeExamCode(int id)
        {
            return db.Exams.ToList();
        }

        //Search Exams
        public List<Exam> GetExamBySearch(ExamSearchCriteria criteria)
        {
            IQueryable<Exam> exams = db.Exams.Where(c => c.IsDeleted == false).AsQueryable();


            if (!string.IsNullOrEmpty(criteria.Topic))
            {
                exams = exams.Where(c => c.Topic.ToLower().Contains(criteria.Topic.ToLower()));
            }


            if (criteria.OrganizationId > 0)
            {
                exams = exams.Where(c =>
                    c.OrganizationId.ToString().ToLower().Contains(criteria.OrganizationId.ToString().ToLower()));
            }

            if (criteria.CourseId > 0)
            {
                exams = exams.Where(c =>
                    c.CourseId.ToString().ToLower().Contains(criteria.CourseId.ToString().ToLower()));
            }

            if (criteria.ExamTypeId > 0)
            {
                exams = exams.Where(c =>
                    c.ExamTypeId.ToString().ToLower().Contains(criteria.ExamTypeId.ToString().ToLower()));
            }

            return exams.ToList();
        }


        public List<Exam> GetExamByCourse(int id)
        {
            List<Exam> exams = db.Exams.Where(c => c.CourseId == id).ToList();
            return exams;
        }

        public bool QuestionAdd(Question question)
        {
            db.Questions.Add(question);
            return db.SaveChanges() > 0;
        }

        public List<Question> MakeQuestionOrder(int id)
        {
            return db.Questions.Where(c => c.ExamId == id).ToList();
        }

        //Question Search
        public List<Question> GetQuestionBySearch(QuestionSearchCriteria criteria)
        {
            IQueryable<Question> questions = db.Questions.AsQueryable();

            if (criteria.OrganizationId > 0)
            {
                questions = questions.Where(c =>
                    c.OrganizationId.ToString().ToLower().Contains(criteria.OrganizationId.ToString().ToLower()));
            }

            if (criteria.CourseId > 0)
            {
                questions = questions.Where(c =>
                    c.CourseId.ToString().ToLower().Contains(criteria.CourseId.ToString().ToLower()));
            }

            if (criteria.ExamId > 0)
            {
                questions = questions.Where(c =>
                    c.ExamId.ToString().ToLower().Contains(criteria.ExamId.ToString().ToLower()));
            }

            return questions.ToList();

        }

        public Question GetQuestionById(int id)
        {
            return db.Questions.Where(c => c.Id == id).FirstOrDefault();
        }
    }
}
