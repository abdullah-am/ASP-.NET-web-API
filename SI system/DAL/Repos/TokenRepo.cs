﻿using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TokenRepo : Repo, IRepo<Token, string, Token>
    {
        public Token Create(Token obj)
        {
            db.Tokens.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(string id)
        {
            var exobj = Get(id);
            db.Tokens.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public Token Get(string id)
        {
            return db.Tokens.SingleOrDefault(t => t.Key.Equals(id));
        }

        public List<Token> GetAll()
        {
            return db.Tokens.ToList();
        }

       

        public Token Update(Token obj)
        {
            var exobj = Get(obj.Key);
            exobj.ExpiredAt = obj.ExpiredAt;
            db.SaveChanges();
            return obj; ;
        }



        public List<Token> GetByStudentId(string SId)
        {
            throw new NotImplementedException();
        }

        public Parent GetWithStudents(string parentId)
        {
            throw new NotImplementedException();
        }


        public bool BulkInsert(List<Student> studentEntities)
        {
            throw new NotImplementedException();
        }
    }
}
