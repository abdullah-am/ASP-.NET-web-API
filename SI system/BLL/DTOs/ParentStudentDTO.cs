using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ParentStudentDTO :ParentDTO
    {
        public List<StudentDTO> Students{ get; set; }
        public ParentStudentDTO()
        {
            Students = new List<StudentDTO>();
        }

    }
}
