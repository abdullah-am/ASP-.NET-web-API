using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ClassScheduleDTO
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public string ClassDay { get; set; }
        public string ClassTime { get; set; }
        public int SId { get; set; }
    }
}
