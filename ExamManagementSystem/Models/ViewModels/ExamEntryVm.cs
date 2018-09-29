using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models.ViewModels
{
    public class ExamEntryVm
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int CourseId { get; set; }
        public int ExamTypeId { get; set; }
        public string Code { get; set; }
        public string Topic { get; set; }
        public double FullMarks { get; set; }
        public bool IsDeleted { get; set; }

        public Organization Organization { get; set; }
        public Course Course { get; set; }
        public ExamType ExamType { get; set; }
        public List<SelectListItem> OrganizationListItem { get; set; }
        public List<SelectListItem> ExamTypeListItem { get; set; }

    }
}
