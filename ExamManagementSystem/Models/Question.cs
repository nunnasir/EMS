using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models
{
    public class Question
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int CourseId { get; set; }
        public int ExamId { get; set; }
        public int QOrder { get; set; }
        public double Marks { get; set; }
        public string Name { get; set; }

        public virtual List<QuestionOptions> QuestionOptionses { get; set; }

        [NotMapped]
        public Organization Organization { get; set; }
        [NotMapped]
        public Course Course { get; set; }
        [NotMapped]
        public Exam Exam { get; set; }


        [NotMapped]
        public List<SelectListItem> OrganizationListItem { get; set; }

    }
}
