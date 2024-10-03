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
    public class ClassScheduleService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClassSchedule,ClassScheduleDTO>();
                cfg.CreateMap<ClassScheduleDTO,ClassSchedule>();

            });
            return new Mapper(config);
        }


        public static bool Create(ClassScheduleDTO obj)
        {
            var data = GetMapper().Map<ClassSchedule>(obj);
            return DataAccess.ClassScheduledata().Create(data);
        }
        public static List<ClassScheduleDTO> GetAll()
        {
            var data = DataAccess.ClassScheduledata().GetAll();
            return GetMapper().Map<List<ClassScheduleDTO>>(data);
        }
        public static ClassScheduleDTO Get(int id)
        {
            var data = DataAccess.ClassScheduledata().Get(id);
            return GetMapper().Map<ClassScheduleDTO>(data);
        }
        public static bool Update(ClassScheduleDTO obj)
        {
            var data = GetMapper().Map<ClassSchedule>(obj);
            return DataAccess.ClassScheduledata().Update(data);
        }
        public static bool Delete(int id)
        {
            return DataAccess.ClassScheduledata().Delete(id);
        }


        public static List<ClassScheduleDTO> GetByStudentId(int SId)
        {
            var data = DataAccess.ClassScheduledata().GetByStudentId(SId);
            return GetMapper().Map<List<ClassScheduleDTO>>(data);
        }


    }
}
