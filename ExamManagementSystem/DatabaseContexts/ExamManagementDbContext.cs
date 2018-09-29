using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DatabaseContexts
{
    public class ExamManagementDbContext:DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamType> ExamTypes { get; set; }
    }
}
