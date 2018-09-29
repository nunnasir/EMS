using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models.SearchCriteria
{
    public class ExamSearchCriteria
    {
        public int OrganizationId { get; set; }
        public int CourseId { get; set; }
        public int ExamTypeId { get; set; }
        [Display(Name = "Exam Topic")]
        public string Topic { get; set; }

        public Organization Organization { get; set; }
        public Course Course { get; set; }
        public ExamType ExamType { get; set; }

        public List<SelectListItem> OrganizationListItem { get; set; }
        public List<SelectListItem> ExamTypeListItem { get; set; }
        public List<Exam> Exams { get; set; }
    }
}
