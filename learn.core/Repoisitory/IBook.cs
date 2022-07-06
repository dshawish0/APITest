using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Repoisitory
{
    public interface IBook
    {
        public List<api_book> GetAllBook();
        public bool InsertBook(api_book book);
        public bool DeleteBook(int BKID);
        public bool UpdateBook(api_book book);

        public int countOfbooks();

        public int countOfbooksCourse(int CId);

    }
}
