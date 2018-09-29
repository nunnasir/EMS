using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
