using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.SearchCriteria;
using Models.ViewModels;
using Repository;

namespace BLL
{
    public class BatchManager
    {
        BatchRepository _batchRepository = new BatchRepository();

        public List<Organization> GetAllOrganization()
        {
            return _batchRepository.GetAllOrgnization();
        }

        public List<Course> GetCourseByOrganizationId(int id)
        {
            return _batchRepository.GetCourseByOrganizationId(id);
        }

        public bool Add(Batch batch)
        {
            return _batchRepository.Add(batch);
        }

        public List<Batch> GetBatchBySearch(BatchSearchCriteria model)
        {
            List<Batch> batches = _batchRepository.GetBatchBySearch(model);
            return batches;
        }

        public List<Batch> GetBatchNoByCourseId(int id)
        {
            return _batchRepository.GetBatchNoByCourseId(id);
        }

        public Batch GetById(int id)
        {
            return _batchRepository.GetById(id);
        }

        public bool Update(Batch batch)
        {
            return _batchRepository.Update(batch);
        }

        public bool Delete(int id)
        {
            return _batchRepository.Delete(id);
        }
    }
}
