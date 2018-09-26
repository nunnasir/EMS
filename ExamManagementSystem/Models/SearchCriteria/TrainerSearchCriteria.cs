using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models.SearchCriteria
{
    public class TrainerSearchCriteria
    {
        public int OrganizationId { get; set; }
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }

        public List<SelectListItem> OrganizationList { get; set; }
        public List<SelectListItem> CountryList { get; set; }
        public List<Trainer> TrainerList { get; set; }

    }
}
