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
    public class TrainerManager
    {
        TrainerRepository _trainerRepository = new TrainerRepository();
        
        //Get All Organization
        public List<Organization> GetAllOrganization()
        {
            return _trainerRepository.GetAllOrgnization();
        }

        //Get All Course Againts Organization
        public List<Course> GetCourseByOrganizationId(int id)
        {
            return _trainerRepository.GetCourseByOrganizationId(id);
        }

        //Add Trainer
        public bool Add(Trainer trainer)
        {
            return _trainerRepository.Add(trainer);
        }

        //Get All Trainer
        public List<Trainer> GetTrainerBySearch(TrainerSearchCriteria model)
        {
            List<Trainer> trainer = _trainerRepository.GetTrainerBySearch(model);
            return trainer;
        }

        //Get Trainer By Id
        public Trainer GetById(int id)
        {
            return _trainerRepository.GetById(id);
        }

        //Update Trainer
        public bool Update(Trainer trainer)
        {
            return _trainerRepository.Update(trainer);
        }

        //Delete Trainer
        public bool Delete(int id)
        {
            return _trainerRepository.Delete(id);
        }

        //Get Batch Againts Course
        public List<Batch> GetBatchByCourseId(int id)
        {
            return _trainerRepository.GetBatchByCourseId(id);
        }

        //Get All Countries
        public List<Country> GetAllCountries()
        {
            return _trainerRepository.GetAllCountries();
        }

        //Get City Againts Countries
        public List<City> GetCitiesByCountry(int id)
        {
            return _trainerRepository.GetCitiesByCountry(id);
        }


    }
}
