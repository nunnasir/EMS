using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.SearchCriteria;
using Repository;

namespace BLL
{
    public class OrganizationManager
    {
        OrganizationRepository _organizationRepository = new OrganizationRepository();

        public List<Organization> GetOrganizationBySearch(OrganizationSearchCriteria criteria)
        {
            List<Organization> organizations = _organizationRepository.GetOrganizationBySearch(criteria);
            return organizations;
        }

        public bool Add(Organization organization)
        {
            return _organizationRepository.Add(organization);
        }

        public Organization GetById(int id)
        {
            return _organizationRepository.GetById(id);
        }

        public bool Update(Organization organization)
        {
            return _organizationRepository.Update(organization);
        }

        public bool Delete(int id)
        {
            return _organizationRepository.Delete(id);
        }

        public List<Organization> MakeOrganizationCode()
        {
            return _organizationRepository.MakeOrganizationCode();
        }
    }
}
