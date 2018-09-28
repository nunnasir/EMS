using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseContexts;
using Models;
using Models.SearchCriteria;

namespace Repository
{
    public class ParticipantRepository
    {
        ExamManagementDbContext db = new ExamManagementDbContext();

        //Get All Organization
        public List<Organization> GetAllOrgnization()
        {
            List<Organization> organizations = db.Organizations.Where(c => c.IsDeleted == false).ToList();
            return organizations;
        }

        //Get Courses Againts Organization
        public List<Course> GetCourseByOrganizationId(int id)
        {
            var course = db.Courses.Where(c => c.OrganizationId == id && c.IsDeleted == false).ToList();
            return course;
        }

        //Add Participant
        public bool Add(Participant participant)
        {
            db.Participants.Add(participant);

            return db.SaveChanges() > 0;
        }

        //Get All Participant
        public List<Participant> GetParticipantBySearch(ParticipantSearchCriteria criteria)
        {
            IQueryable<Participant> participants = db.Participants.Where(c => c.IsDeleted == false).AsQueryable();

            if (!string.IsNullOrEmpty(criteria.Name))
            {
                participants = participants.Where(c => c.Name.ToLower().Contains(criteria.Name.ToLower()));
            }

            if (criteria.OrganizationId > 0)
            {
                participants = participants.Where(c =>
                    c.OrganizationId.ToString().Contains(criteria.OrganizationId.ToString()));
            }

            if (criteria.CourseId > 0)
            {
                participants = participants.Where(c => c.CourseId.ToString().Contains(criteria.CourseId.ToString()));
            }

            if (criteria.CountryId > 0)
            {
                participants = participants.Where(c => c.CountryId.ToString().Contains(criteria.CountryId.ToString()));
            }

            if (criteria.CityId > 0)
            {
                participants = participants.Where(c => c.CityId.ToString().Contains(criteria.CityId.ToString()));
            }

            if (!string.IsNullOrEmpty(criteria.Email))
            {
                participants = participants.Where(c => c.Email.ToLower().Contains(criteria.Email.ToLower()));
            }


            return participants.ToList();
        }


        //Get Participant By Id
        public Participant GetById(int id)
        {
            var data = db.Participants.Where(c => c.Id == id).FirstOrDefault();
            return data;
        }

        //Update Participants
        public bool Update(Participant participant)
        {
            db.Entry(participant).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        //Delete Participants
        public bool Delete(int id)
        {
            Participant participant = new Participant();
            participant = db.Participants.Where(c => c.Id == id).FirstOrDefault();

            if (participant != null)
            {
                participant.IsDeleted = true;
                return Update(participant);
            }

            return false;
        }


        //Get Batch Againts Course
        public List<Batch> GetBatchByCourseId(int id)
        {
            var batch = db.Batches.Where(c => c.CourseId == id && c.IsDeleted == false).ToList();
            return batch;
        }

        //Get All Countries
        public List<Country> GetAllCountries()
        {
            List<Country> countries = db.Countries.ToList();
            return countries;
        }

        //Get city Againts COuntries
        public List<City> GetCitiesByCountry(int id)
        {
            var cities = db.Cities.Where(c => c.CountryId == id).ToList();
            return cities;
        }

        public List<Participant> MakeParticipantRegNo(int id)
        {
            return db.Participants.ToList();
        }
    }
}
