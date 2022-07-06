using Dapper;
using learn.core.Data;
using learn.core.domain;
using learn.core.Repoisitory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace learn.infra.Repoisitory
{
    public class api_bookrepoisitory:IBook
    {
        private readonly IDBContext dBContext;

        public api_bookrepoisitory(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public int countOfbooks()
        {
            List<api_book> c = GetAllBook();

            return c.Count;
        }

        public int countOfbooksCourse(int CId)
        {
            List<api_book> c = GetAllBook();
            int countOfbooks = 0;
            foreach (var book in c)
            {
                if (book.COURSEID == CId)
                    countOfbooks++;
            }
            return countOfbooks;
        }

        public bool DeleteBook(int BKID)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("BkId", BKID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync
                ("API_BOOK_Package.DeleteBook", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }

        public List<api_book> GetAllBook()
        {
            IEnumerable<api_book> result = dBContext.dbConnection.Query<api_book>
                 ("API_BOOK_Package.GetAllBook", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool InsertBook(api_book book)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("BName", book.BOOKNAME, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("Pprice", book.PRICE, dbType: DbType.Double, direction: ParameterDirection.Input);
            parameter.Add
              ("PED", book.PUBLISHEDDATE, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add
             ("EndD", book.ENDDATE, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add
                ("CID", book.COURSEID, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dBContext.dbConnection.ExecuteAsync
                ("API_BOOK_Package.InsertBook", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }

        public bool UpdateBook(api_book book)
        {
            throw new NotImplementedException();
        }
    }
}
