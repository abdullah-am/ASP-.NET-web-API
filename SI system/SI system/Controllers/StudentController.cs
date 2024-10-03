using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SI_system.Controllers
{
    [RoutePrefix("api/student")]
    public class StudentController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = StudentService.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = StudentService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(StudentDTO obj)
        {
            try
            {
                var data = StudentService.Create(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(StudentDTO obj)
        {
            try
            {
                var data = StudentService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = StudentService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }



        [HttpPost]
        [Route("upload")]
        public HttpResponseMessage UploadStudentRecords()
        {
            try
            {
                
                if (!Request.Content.IsMimeMultipartContent())
                {
                    return Request.CreateResponse(HttpStatusCode.UnsupportedMediaType, "Invalid file format.");
                }

                
                var provider = new MultipartMemoryStreamProvider();
                Request.Content.ReadAsMultipartAsync(provider).Wait();

                
                var file = provider.Contents[0];
                var fileStream = file.ReadAsStreamAsync().Result;
                var fileName = file.Headers.ContentDisposition.FileName.Trim('\"');

                if (fileName.EndsWith(".csv"))
                {
                    
                    var result = StudentService.BulkUpload(fileStream);
                    if (result)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "File uploaded and processed successfully.");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Error processing the file.");
                    }
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.UnsupportedMediaType, "Only CSV files are allowed.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


    }
}
