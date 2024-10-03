using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StudentService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student,StudentDTO>();
                cfg.CreateMap<StudentDTO,Student>();
                cfg.CreateMap<Student,StudentAttendanceDTO>();
                cfg.CreateMap<Attendance,AttendanceDTO>();
                cfg.CreateMap<Student,StudentClassScheduleDTO>();
                cfg.CreateMap<ClassSchedule,ClassScheduleDTO>();
            });
            return new Mapper(config);
        }

        public static bool Create(StudentDTO obj)
        { 
            var data=GetMapper().Map<Student>(obj);
            return DataAccess.Studentdata().Create(data);
        }

        public static List<StudentDTO>GetAll()
        {
            var data = DataAccess.Studentdata().GetAll();
            return GetMapper().Map<List<StudentDTO>>(data);
        }

        public static StudentDTO Get(int id) 
        {
            var data = DataAccess.Studentdata().Get(id);
            return GetMapper().Map<StudentDTO>(data);
        }

        public static bool Update(StudentDTO obj)
        {
            var data = GetMapper().Map<Student>(obj);
            return DataAccess.Studentdata().Update(data);
        }
        public static bool Delete(int id)
        {
            return DataAccess.Studentdata().Delete(id);
        }

        public static StudentAttendanceDTO GetWithStudentAttendance(int id)
        {
            var data = DataAccess.Studentdata().Get(id);
            return GetMapper().Map<StudentAttendanceDTO>(data);
        }
        public static StudentClassScheduleDTO GetWithStudentClassSchedule(int id)
        {
            var data = DataAccess.Studentdata().Get(id);
            return GetMapper().Map<StudentClassScheduleDTO>(data);
        }




        public static bool BulkUpload(Stream fileStream)
        {
            try
            {
                var students = new List<StudentDTO>();

                using (var reader = new StreamReader(fileStream))
                {
                    
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        
                        var student = new StudentDTO
                        {
                            Name = values[0],
                            age = int.Parse(values[1]),
                            Grade = values[2],
                            address = values[3],
                            ParentId= int.Parse(values[4])
                        };

                        students.Add(student);
                    }
                }

               
                var studentEntities = GetMapper().Map<List<Student>>(students);
                return DataAccess.Studentdata().BulkInsert(studentEntities);
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }




    }
}
