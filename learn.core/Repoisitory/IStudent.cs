using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Repoisitory
{
    public interface IStudent
    {
        public List<api_student> GetAllStudent();
        public bool InsertStudent(api_student std);
        public bool DeleteStudent(int stdId);
        public bool UpdateStudent(api_student std);


        public string marks();

        
    }
}
