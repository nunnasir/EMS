using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models.ViewModels
{
    public class TrainerEntryVm
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int CourseId { get; set; }
        public int BatchId { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string PostalCode { get; set; }
        public byte[] Image { get; set; }

        public Organization Organization { get; set; }
        public Course Course { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }

        public List<SelectListItem> OrganizationList { get; set; }
        public List<SelectListItem> CountryList { get; set; }


    }
}
