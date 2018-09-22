using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models.ViewModels
{
    public class BatchEntryVm
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int BatchNo { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<Trainer> Trainers { get; set; }
        public List<Participant> Participants { get; set; }

        public Course Course { get; set; }
        public int OrganizationId { get; set; }

        public Organization Organization { get; set; }

        public List<SelectListItem> OrganizationList { get; set; }


    }
}
