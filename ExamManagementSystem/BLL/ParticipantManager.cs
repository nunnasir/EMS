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
    public class ParticipantManager
    {
        ParticipantRepository _participantRepository = new ParticipantRepository();

        //Get All Organization
        public List<Organization> GetAllOrganization()
        {
            return _participantRepository.GetAllOrgnization();
        }

        //Get All Course Againts Organization
        public List<Course> GetCourseByOrganizationId(int id)
        {
            return _participantRepository.GetCourseByOrganizationId(id);
        }

        //Add Participant
        public bool Add(Participant participant)
        {
            return _participantRepository.Add(participant);
        }

        //Get All Participant
        public List<Participant> GetTrainerBySearch(ParticipantSearchCriteria model)
        {
            List<Participant> participants = _participantRepository.GetParticipantBySearch(model);
            return participants;
        }

        //Get Participant By Id
        public Participant GetById(int id)
        {
            return _participantRepository.GetById(id);
        }

        //Update Participant
        public bool Update(Participant participant)
        {
            return _participantRepository.Update(participant);
        }

        //Delete Trainer
        public bool Delete(int id)
        {
            return _participantRepository.Delete(id);
        }

        //Get Batch Againts Course
        public List<Batch> GetBatchByCourseId(int id)
        {
            return _participantRepository.GetBatchByCourseId(id);
        }

        //Get All Countries
        public List<Country> GetAllCountries()
        {
            return _participantRepository.GetAllCountries();
        }

        //Get City Againts Countries
        public List<City> GetCitiesByCountry(int id)
        {
            return _participantRepository.GetCitiesByCountry(id);
        }

    }
}
