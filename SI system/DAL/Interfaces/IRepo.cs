using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<CLASS,ID,RET>
    {
        RET Create(CLASS obj);
        List<CLASS> GetAll();
        CLASS Get(ID id);
        RET Update(CLASS obj);
        bool Delete(ID id);
        List<CLASS>GetByStudentId(ID SId);
        Parent GetWithStudents(ID parentId);
        bool BulkInsert(List<Student> studentEntities);
    }

}
