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
    public class AttendanceService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Attendance,AttendanceDTO>();
                cfg.CreateMap<AttendanceDTO,Attendance>();
            });
            return new Mapper(config);
        }

        public static bool Create(AttendanceDTO obj)
        {
            var data = GetMapper().Map<Attendance>(obj);
            return DataAccess.Attendancedata().Create(data);
        }
        public static List<AttendanceDTO> GetAll()
        {
            var data = DataAccess.Attendancedata().GetAll();
            return GetMapper().Map<List<AttendanceDTO>>(data);
        }
        public static AttendanceDTO Get(int id)
        {
            var data = DataAccess.Attendancedata().Get(id);
            return GetMapper().Map<AttendanceDTO>(data);
        }
        public static bool Update(AttendanceDTO obj)
        {
            var data = GetMapper().Map<Attendance>(obj);
            return DataAccess.Attendancedata().Update(data);
        }
        public static bool Delete(int id)
        {
            return DataAccess.Attendancedata().Delete(id);
        }




        public static List<AttendanceDTO> GetByStudentId(int SId)
        {
            var data = DataAccess.Attendancedata().GetByStudentId(SId);
            return GetMapper().Map<List<AttendanceDTO>>(data);
        }



    }
}
