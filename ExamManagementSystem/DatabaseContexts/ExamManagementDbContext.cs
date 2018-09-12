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
    }
}
