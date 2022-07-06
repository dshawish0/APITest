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
    public class API_BOOK : ControllerBase
    {
        private readonly IBookService bookService;

        public API_BOOK(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpDelete("delete/{id}")]
        public bool DeleteBook(int courseId)
        {
            return bookService.DeleteBook(courseId);
        }

        [HttpGet]
        public List<api_book> GetAllBook()
        {
            return bookService.GetAllBook();
        }
        [HttpPost]
        public bool InsertBook([FromBody] api_book book)
        {
            return bookService.InsertBook(book);
        }

        [HttpGet]
        [Route("count")]
        public int countOfbooks()
        {
            return bookService.countOfbooks();
        }

        [HttpGet]
        [Route("countof/{CId}")]
        public int countOfbooksCourse(int CId)
        {
            return bookService.countOfbooksCourse(CId);
        }
    }
}
