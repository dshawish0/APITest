using learn.core.Data;
using learn.core.Repoisitory;
using learn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.Service
{
    public class BookService : IBookService
    {
        private readonly IBook api_Bookpoisitory;
        public BookService(IBook api_Bookpoisitory)
        {
            this.api_Bookpoisitory = api_Bookpoisitory;
        }

        public int countOfbooks()
        {
            return api_Bookpoisitory.countOfbooks();
        }

        public int countOfbooksCourse(int CId)
        {
            return api_Bookpoisitory.countOfbooksCourse(CId);
        }

        public bool DeleteBook(int BKID)
        {
            return api_Bookpoisitory.DeleteBook(BKID);
        }

        public List<api_book> GetAllBook()
        {
            return api_Bookpoisitory.GetAllBook();
        }

        public bool InsertBook(api_book book)
        {
            return api_Bookpoisitory.InsertBook(book);
        }

        public bool UpdateBook(api_book book)
        {
            return api_Bookpoisitory.UpdateBook(book);
        }
    }
}
