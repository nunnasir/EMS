using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class City
    {
        public int Id { get; set; }
        [Display(Name = "City Name")]
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
