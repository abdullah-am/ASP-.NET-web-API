using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class StudentRepo : Repo, IRepo<Student, int, bool>
    {
        public bool Create(Student obj)
        {
           db.Students.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Students.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public Student Get(int id)
        {
            return db.Students.Find(id);
        }

        public List<Student> GetAll()
        {
            return db.Students.ToList();
        }

        public bool Update(Student obj)
        {
            var exobj = Get(obj.Id);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }



        public List<Student> GetByStudentId(int sId)
        {
            throw new NotImplementedException();
        }


        public Parent GetWithStudents(int parentId)
        {
            throw new NotImplementedException();
        }



        public bool BulkInsert(List<Student> studentEntities)
        {
            try
            {
                db.Students.AddRange(studentEntities);
                return db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
