using learn.core.Data;
using learn.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Service
{
    public interface IStudentService
    {
        public List<api_student> GetAllStudent();
        public bool InsertStudent(api_student std);
        public bool DeleteStudent(int stdId);
        public bool UpdateStudent(api_student std);

        public string marks();

        public List<std_dto> getDetails();
    }
}
