using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class StudentClassScheduleDTO :StudentDTO
    {
        public List<ClassScheduleDTO> ClassSchedules { get; set; }
        public StudentClassScheduleDTO()
        {
            ClassSchedules = new List<ClassScheduleDTO>();
        }
    }
}
