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
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Contact Number Must be 11 Digit")]
        public string ContactNo { get; set; }
        public string About { get; set; }
        public bool IsDeleted { get; set; }
        public CourseEntryVm CourseVm { get; set; }

        public List<CourseEntryVm> Courses { get; set; }
        public List<Trainer> Trainers { get; set; }
        public List<Participant> Participants { get; set; }
        public List<Organization> Organizations { get; set; }

    }
}
