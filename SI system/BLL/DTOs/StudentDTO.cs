using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int age { get; set; }
        public string Grade { get; set; }
        public string address { get; set; }
        public int ParentId { get; set; }
    }
}
