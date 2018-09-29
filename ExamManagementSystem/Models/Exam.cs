using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Exam
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int CourseId { get; set; }
        public int ExamTypeId { get; set; }
        public string Code { get; set; }
        [Display(Name = "Exam Topic")]
        public string Topic { get; set; }
        public double FullMarks { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual Course Course { get; set; }
        public virtual ExamType ExamType { get; set; }
    }
}
