using learn.core.Data;
using learn.core.Service;
using learn.infra.Service;
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
    public class API_COURSE : ControllerBase
    {
        private readonly ICourseService courseService;

        public API_COURSE(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpDelete("delete/{id}")]
        public bool DeleteCourse(int courseId)
        {
            return courseService.DeleteCourse(courseId);
        }

        [HttpGet]
        public List<api_course> GetAllCourse()
        {
            return courseService.GetAllCourse();
        }
        [HttpPost]
        public api_course InsertCourse([FromBody] api_course course)
        {
            return courseService.InsertCourse(course);
        }
        [HttpPut]
        public bool UpdateCourse([FromBody] api_course course)
        {
            return courseService.UpdateCourse(course);
        }
        [HttpGet("{id}")]
        public api_course course(int id)
        {
            return courseService.getById(id);
        }
        [HttpPut]
        [Route("updateCourseName")]
        public bool updateCourseName([FromBody] string name)
        {
            return courseService.updateCourseName(name);
        }

        [HttpGet]
        [Route("count")]
        public int countOfCourses()
        {
            return courseService.countOfCourses();
        }

        [HttpGet]
        [Route("coursesdetalils")]
        public string coursesDetalils()
        {
            return courseService.coursesDetalils();
        }

        [HttpGet]
        [Route("last3rec")]
        public List<api_course> last3rec()
        {
            return courseService.last3rec();
        }

        [HttpGet]
        [Route("orderbydescning")]
        public List<api_course> orderbydescning()
        {
            return courseService.orderbydescning();
        }

        [HttpPost]
        [Route("list")]
        public List<api_course> InsertCourseList([FromBody] api_course[] course)
        {
            return courseService.InsertCourseList(course);
        }

        [HttpGet("filter/{c}")]
        public List<api_course> filter(char c)
        {
            return courseService.filter(c);
        }
        //
    }
}
