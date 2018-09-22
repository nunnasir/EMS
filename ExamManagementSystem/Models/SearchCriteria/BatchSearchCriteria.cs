using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.ViewModels;

namespace Models.SearchCriteria
{
    public class BatchSearchCriteria
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int BatchNo { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<Batch> ListOfBatch { get; set; }

    }
}

