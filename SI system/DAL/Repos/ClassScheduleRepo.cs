using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ClassScheduleRepo : Repo, IRepo<ClassSchedule, int, bool>
    {
        public bool Create(ClassSchedule obj)
        {
            db.ClassSchedules.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.ClassSchedules.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public ClassSchedule Get(int id)
        {
            return db.ClassSchedules.Find(id);
        }

        public List<ClassSchedule> GetAll()
        {
            return db.ClassSchedules.ToList();
        }

        public bool Update(ClassSchedule obj)
        {
            var exobj = Get(obj.Id);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }



        public List<ClassSchedule> GetByStudentId(int SId)
        {
            return db.ClassSchedules.Where(a => a.SId == SId).ToList();
        }


        public Parent GetWithStudents(int parentId)
        {
            throw new NotImplementedException();
        }


        public bool BulkInsert(List<Student> studentEntities)
        {
            throw new NotImplementedException();
        }

    }
}
