using learn.core.Data;
using learn.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class API_STUDENT : ControllerBase
    {
        private readonly IStudentService StudentService;

        public API_STUDENT(IStudentService StudentService)
        {
            this.StudentService = StudentService;
        }

        [HttpGet]
        public List<api_student> GetAllCourse()
        {
            return StudentService.GetAllStudent();
        }

        [HttpGet]
        [Route("marks")]
        public string marks()
        {
            return StudentService.marks();
        }
    }
}
