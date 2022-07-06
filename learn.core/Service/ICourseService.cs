using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Service
{
    public interface ICourseService
    {
        public List<api_course> GetAllCourse();
        public api_course InsertCourse(api_course course);
        public bool DeleteCourse(int courseId);
        public bool UpdateCourse(api_course course);
        public api_course getById(int id);
        public bool updateCourseName(string name);

        public int countOfCourses();
        public string coursesDetalils();
        public List<api_course> last3rec();
        public List<api_course> orderbydescning();
        public List<api_course> InsertCourseList(api_course[] course);
        public List<api_course> filter(char c);
    }
}
