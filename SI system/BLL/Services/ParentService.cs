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
    public class ParentService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Parent, ParentDTO>();
                cfg.CreateMap<ParentDTO,Parent>();
                cfg.CreateMap<Parent, ParentStudentDTO>();
                cfg.CreateMap<Student,StudentDTO>();
            });
            return new Mapper(config);
        }

        public static bool Create(ParentDTO obj)
        {
            var data = GetMapper().Map<Parent>(obj);
            return DataAccess.ParentData().Create(data);
        }
        public static List<ParentDTO> GetAll()
        {
            var data = DataAccess.ParentData().GetAll();
            return GetMapper().Map<List<ParentDTO>>(data);
        }
        public static ParentDTO Get(int id)
        {
            var data = DataAccess.ParentData().Get(id);
            return GetMapper().Map<ParentDTO>(data);
        }
        public static bool Update(ParentDTO obj)
        {
            var data = GetMapper().Map<Parent>(obj);
            return DataAccess.ParentData().Update(data);
        }
        public static bool Delete(int id)
        {
            return DataAccess.ParentData().Delete(id);
        }
        public static ParentStudentDTO GetWithParents(int id)
        {
            var data = DataAccess.ParentData().Get(id);
            return GetMapper().Map<ParentStudentDTO>(data);
        }



        public static ParentStudentDTO GetParentWithStudents(int parentId)
        {
            var data = DataAccess.ParentData().GetWithStudents(parentId);
            return GetMapper().Map<ParentStudentDTO>(data);
        }


    }
}
