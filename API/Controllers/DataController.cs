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
    public class DataController : ControllerBase
    {
        private readonly IBookService bookService;
        private readonly ICourseService courseService;

        public DataController(ICourseService courseService, IBookService bookService)
        {
            this.courseService = courseService;
            this.bookService = bookService;
        }

        [HttpGet]
        public List<object> GetAll()
        {
            List<api_course> c = courseService.GetAllCourse();
            List<api_book> b = bookService.GetAllBook();

            

            List <Object> o = new List<object>();

            foreach (var course in c)
            {
                List<Object> bb = new List<Object>();

                bb.Add(course);
                foreach (var book in b)
                {
                    if (book.COURSEID == course.CourseId)
                            bb.Add(book);
                }
                o.Add(bb);
            }

            return o;
        }
    }
}
