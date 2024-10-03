using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class Parent
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        public string FatherName { get; set; }
        [Required]
        public string MotherName { get; set; }

        [Required]
        public int phone {  get; set; }
        public virtual ICollection<Student> Students { get; set; }

        public Parent()
        {
            Students = new List<Student>();
        }
    }
}
