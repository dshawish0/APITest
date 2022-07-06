using Dapper;
using learn.core.Data;
using learn.core.domain;
using learn.core.Repoisitory;
using learn.infra.domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace learn.infra.Repoisitory
{
    public class api_studentrepoisitory : IStudent
    {
        private readonly IDBContext dBContext;

        public api_studentrepoisitory(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public bool DeleteStudent(int stdId)
        {
            throw new NotImplementedException();
        }

        public List<api_student> GetAllStudent()
        {
            IEnumerable<api_student> result = dBContext.dbConnection.Query<api_student>
                ("API_STUDENT_Package.GetAllStudent", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public bool InsertStudent(api_student std)
        {
            throw new NotImplementedException();
        }

        public string marks()
        {
            List<api_student> result = GetAllStudent();

            string marks = "";
            foreach(var std in result)
            {
                marks += std.Fname + " " +std.StudentMark+"\n";
            }
            return marks;
        }

        public bool UpdateStudent(api_student std)
        {
            throw new NotImplementedException();
        }
    }
}
