using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, string, bool>, IAuth
    {
        public bool Create(User obj)
        {
            db.Users.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(string id)
        {
            var exobj = Get(id);
            if (exobj == null) return false;
            db.Users.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public User Get(string id)
        {
            return db.Users.Find(id);
        }

        public List<User> GetAll()
        {
            return db.Users.ToList();
        }


        public bool Update(User obj)
        {
            var exobj = Get(obj.Username);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        public List<User> GetByStudentId(string SId)
        {
            throw new NotImplementedException();
        }

        public Parent GetWithStudents(string parentId)
        {
            throw new NotImplementedException();
        }


        public bool Authenticate(string Username, string Password)
        {
            var user = db.Users.SingleOrDefault(
                    u => u.Username.Equals(Username) &&
                    u.Password.Equals(Password)
                );
            return user != null;
        }



        public bool BulkInsert(List<Student> studentEntities)
        {
            throw new NotImplementedException();
        }


    }
}
