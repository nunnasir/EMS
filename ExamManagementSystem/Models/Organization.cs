using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models
{
    public class Organization 
    {
        public int Id { get; set; }

        [Display(Name = "Organization")]
        public string Name { get; set; }
        public List<Course> Courses { get; set; }
        
        [NotMapped]
        public List<SelectListItem> OrganizationSelectListItems { get; set; }

    }
}
