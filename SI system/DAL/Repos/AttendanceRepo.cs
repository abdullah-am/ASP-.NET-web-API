using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AttendanceRepo : Repo, IRepo<Attendance, int, bool>
    {
        public bool Create(Attendance obj)
        {
            db.Attendances.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Attendances.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public Attendance Get(int id)
        {
            return db.Attendances.Find(id);
        }

        public List<Attendance> GetAll()
        {
            return db.Attendances.ToList();
        }

        public bool Update(Attendance obj)
        {
            var exobj = Get(obj.Id);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }


        public List<Attendance> GetByStudentId(int SId)
        {
            return db.Attendances.Where(a => a.SId == SId).ToList();
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
