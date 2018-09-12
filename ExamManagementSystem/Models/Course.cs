using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models
{
    public class Course
    {
        public Course()
        {
            OrganizationListItem = new List<SelectListItem>();
        }

        public int Id { get; set; }
        public Organization Organization { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Duration { get; set; }
        public int Credit { get; set; }
        public string Outline { get; set; }
        public string Tag { get; set; }

        

        //public string OrganizationId()
        //{
        //    return Organization.Id.ToString();
        //}
        
        [NotMapped]
        public List<SelectListItem> OrganizationListItem { get; set; }

    }
}
