using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class Student
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        public string Grade { get; set; }
        [Required]
        public string address { get; set; }

        [ForeignKey("Parent")]
        public int ParentId { get; set; }

        public virtual Parent Parent { get; set; }

        public virtual ICollection<Attendance> AttendanceRecords { get; set; }
        public virtual ICollection<ClassSchedule> ClassSchedules { get; set; }

        public Student()
        {
            AttendanceRecords = new List<Attendance>();
            ClassSchedules = new List<ClassSchedule>();
        }
    }
}
