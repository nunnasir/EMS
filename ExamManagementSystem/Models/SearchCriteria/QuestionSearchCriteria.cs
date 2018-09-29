using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models.SearchCriteria
{
    public class QuestionSearchCriteria
    {
        public int OrganizationId { get; set; }
        public int CourseId { get; set; }
        public int ExamId { get; set; }
        public int QOrder { get; set; }
        public string Name { get; set; }
        public virtual List<QuestionOptions> QuestionOptionses { get; set; }



        public List<Question> Questions { get; set; }

        public List<SelectListItem> OrganizationListItem { get; set; }
    }
}
