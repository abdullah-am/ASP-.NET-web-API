using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Token,TokenDTO>();
                cfg.CreateMap<SignUpDTO, User>();
            });
            return new Mapper(config);
        }



        public static bool SignUp(SignUpDTO signup)
        {
            
            var existingUserByUsername = DataAccess.UserData().Get(signup.Username);
            var existingUserByEmail = DataAccess.UserData().GetAll().FirstOrDefault(u => u.Email == signup.Email);

            if (existingUserByUsername != null || existingUserByEmail != null)
            {
                
                return false;
            }

            
            var newUser = GetMapper().Map<User>(signup);

            
            return DataAccess.UserData().Create(newUser);
        }






        public static TokenDTO Authenticate(string Username, string Password)
        {
            var data = DataAccess.AuthData().Authenticate(Username, Password);
            if (data)
            {
                Token t = new Token();
                t.CreatedAt = DateTime.Now;
                t.Key = Guid.NewGuid().ToString();
                t.Username = Username;
                var token = DataAccess.Tokendata().Create(t);
                return GetMapper().Map<TokenDTO>(token);
            }

            return null;
        }


        public static bool LogoutToken(string key)
        {
            if (DataAccess.Tokendata().Get(key) != null)
            {
                Token token = new Token();
                token.Key = key;
                token.ExpiredAt = DateTime.Now;
                var ret = DataAccess.Tokendata().Update(token);
                // return ret != null;
                if (ret != null)
                {
                  
                    var deleted = DataAccess.Tokendata().Delete(key);

                    
                    return deleted;
                }
            }


            return false;


        }


        public static bool IsTokenValid(string key)
        {
            var token = DataAccess.Tokendata().Get(key);
            if (token != null && token.ExpiredAt == null) return true;
            return false;
        }
        //public static bool IsTokenValidAdmin(string key)
        //{
        //    var token = DataAccess.Tokendata().Get(key);
        //    if (token != null && token.ExpiredAt == null &&
        //        token.User.Role.Equals("Admin")) return true;
        //    return false;

        //}



    }
}
