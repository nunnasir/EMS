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

    }
}
