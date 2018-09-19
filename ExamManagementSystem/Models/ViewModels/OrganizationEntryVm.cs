using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models.ViewModels
{
    public class OrganizationEntryVm
    {
        public int Id { get; set; }

        [Display(Name = "Organization")]
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public List<Course> Courses { get; set; }

    }
}
