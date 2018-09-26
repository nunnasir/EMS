using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Trainer
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
        public bool IsDeleted { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual Course Course { get; set; }
        public virtual City City { get; set; }
        public virtual Country Country { get; set; }

    }
}
