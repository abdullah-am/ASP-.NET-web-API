using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ParentDTO
    {
        public int Id { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public int phone { get; set; }
    }
}
