using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class Scontext :DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<ClassSchedule> ClassSchedules { get; set; }
        public DbSet<Token> Tokens { get; set; }
    }
}
