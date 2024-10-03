using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class ClassSchedule
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string ClassName { get; set; }

        [Required]
        [StringLength(20)]
        public string ClassDay { get; set; } 

        [Required]
        [StringLength(20)]
        public string ClassTime { get; set; }

        [ForeignKey("Student")]
        public int SId { get; set; }
        public virtual Student Student { get; set; }
    }
}
