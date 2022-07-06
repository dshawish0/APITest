using learn.core.Data;
using learn.core.Repoisitory;
using learn.core.Service;
using learn.infra.Repoisitory;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourse api_Courserepoisitory;
        public CourseService(ICourse api_Courserepoisitory)
        {
            this.api_Courserepoisitory = api_Courserepoisitory;
        }
        public bool DeleteCourse(int courseId)
        {
            return api_Courserepoisitory.DeleteCourse(courseId);
        }

        public List<api_course> GetAllCourse()
        {
            return api_Courserepoisitory.GetAllCourse();
        }

        public api_course getById(int id)
        {
            return api_Courserepoisitory.getById(id);
        }

        public api_course InsertCourse(api_course course)
        {
            return api_Courserepoisitory.InsertCourse(course);
        }

        public bool UpdateCourse(api_course course)
        {
            return api_Courserepoisitory.UpdateCourse(course);
        }

        public bool updateCourseName(string name)
        {
            return api_Courserepoisitory.updateCourseName(name);
        }

        public int countOfCourses()
        {
            return api_Courserepoisitory.countOfCourses();
        }

        public string coursesDetalils()
        {
            return api_Courserepoisitory.coursesDetalils();
        }

        public List<api_course> last3rec()
        {
            return api_Courserepoisitory.last3rec();
        }

        public List<api_course> orderbydescning()
        {
            return api_Courserepoisitory.orderbydescning();
        }

        public List<api_course> InsertCourseList(api_course[] course)
        {
            return api_Courserepoisitory.InsertCourseList(course);
        }

        public List<api_course> filter(char c)
        {
            return api_Courserepoisitory.filter(c);
        }
    }
}
