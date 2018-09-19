using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SearchCriteria
{
    public class OrganizationSearchCriteria
    {

        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public bool IsDeleted { get; set; }

        public List<Course> Courses { get; set; }
        public List<Organization> OrganizationLists { get; set; }

    }
}
