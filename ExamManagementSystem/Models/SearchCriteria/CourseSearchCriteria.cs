using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models.SearchCriteria
{
    public class CourseSearchCriteria
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Duration { get; set; }
        public int Credit { get; set; }
        public string Outline { get; set; }
        public string Tag { get; set; }

        public int CreditForm { get; set; }
        public int CreditTo { get; set; }





        public List<SelectListItem> OrganizationListItem { get; set; }
        public List<Course> Course { get; set; }
    }
}
