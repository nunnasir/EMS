using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Country
    {
        public int Id { get; set; }
        [Display(Name = "Country Name")]
        public string Name { get; set; }
        public List<City> Cities { get; set; }
        public List<Trainer> Trainers { get; set; }
        public List<Participant> Participants { get; set; }
    }
}
