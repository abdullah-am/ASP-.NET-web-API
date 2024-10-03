using DAL.EF.TableModels;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccess
    {

        public static IRepo<User,string,bool>UserData()
        {
            return new UserRepo();
        }
        public static IRepo<Student,int,bool> Studentdata()
        {
            return new StudentRepo();
        }
        public static IRepo<Parent,int,bool> ParentData()
        {
            return new ParentRepo();
        }
        public static IRepo<ClassSchedule, int, bool> ClassScheduledata() 
        {
            return new ClassScheduleRepo();
        }
        public static IRepo<Attendance, int,bool> Attendancedata() 
        { 
            return new AttendanceRepo(); 
        }

        public static IRepo<Token, string,Token> Tokendata() 
        { 
            return new TokenRepo();
        }
        public static IAuth AuthData()
        {
            return new UserRepo();
        }

        
    }
}
