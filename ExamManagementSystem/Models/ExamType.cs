using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ExamType
    {
        public int Id { get; set; }
        [Display(Name = "Exam Type")]
        public string Name { get; set; }
        public List<Exam> Exams { get; set; }
    }
}
