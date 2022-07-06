using learn.core.Data;
using learn.core.Repoisitory;
using learn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudent api_studentpoisitory;
        public StudentService(IStudent api_studentpoisitory)
        {
            this.api_studentpoisitory = api_studentpoisitory;
        }
        public bool DeleteStudent(int stdId)
        {
            return api_studentpoisitory.DeleteStudent(stdId);
        }

        public List<api_student> GetAllStudent()
        {
            return api_studentpoisitory.GetAllStudent();
        }

        public bool InsertStudent(api_student std)
        {
            return api_studentpoisitory.InsertStudent(std);
        }

        public string marks()
        {
            return api_studentpoisitory.marks();
        }

        public bool UpdateStudent(api_student std)
        {
            return api_studentpoisitory.UpdateStudent(std);
        }
    }
}
