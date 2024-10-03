using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Repos
{
    internal class ParentRepo : Repo, IRepo<Parent, int, bool>
    {
        public bool Create(Parent obj)
        {
            db.Parents.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Parents.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public Parent Get(int id)
        {
            return db.Parents.Find(id);
        }

        public List<Parent> GetAll()
        {
            return db.Parents.ToList();
        }

        public bool Update(Parent obj)
        {
            var exobj = Get(obj.Id);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }



        public List<Parent> GetByStudentId(int sId)
        {
            throw new NotImplementedException();
        }



        public Parent GetWithStudents(int parentId)
        {
            return db.Parents.Include(p => p.Students)
                .FirstOrDefault(p => p.Id == parentId);
        }


        public bool BulkInsert(List<Student> studentEntities)
        {
            throw new NotImplementedException();
        }


    }
}
