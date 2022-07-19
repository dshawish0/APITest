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
    public class api_courserepoisitory : ICourse
    {
        private readonly IDBContext dBContext;

        public api_courserepoisitory(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public bool DeleteCourse(int courseId)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("CID", courseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync
                ("API_COURSE_Package.DeleteCourse", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }

        public List<api_course> GetAllCourse()
        {
            IEnumerable<api_course> result = dBContext.dbConnection.Query<api_course>
                ("API_COURSE_Package.GetAllCourse", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public api_course getById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofcourse", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<api_course> result = dBContext.dbConnection.Query<api_course>("API_COURSE_Package.getbyid", parameter, commandType: CommandType.StoredProcedure);
            //return new api_course();
            return result.FirstOrDefault();
        }

        public api_course InsertCourse(api_course course)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("CouName", course.Coursename, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("Pprice", course.Price, dbType: DbType.Double, direction: ParameterDirection.Input);
            parameter.Add
              ("SDate", course.StartDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add
             ("EDate", course.EndDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add
                ("ImgPath", course.ImagePath, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dBContext.dbConnection.ExecuteAsync
                ("API_COURSE_Package.InsertCourse", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return null;
            return course;
        }

        public bool UpdateCourse(api_course course)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("CouName", course.Coursename, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("Pprice", course.Price, dbType: DbType.Double, direction: ParameterDirection.Input);
            parameter.Add
              ("SDate", course.StartDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add
             ("EDate", course.EndDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add
                ("ImgPath", course.ImagePath, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dBContext.dbConnection.ExecuteAsync
               ("API_COURSE_Package.UpdateCourse", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }

        public bool updateCourseName(string name)
        {
            throw new NotImplementedException();
        }

        public int countOfCourses()
        {
            List<api_course> c = GetAllCourse();

            return c.Count;
        }

        public string coursesDetalils()
        {
            List<api_course> c = GetAllCourse();
            double sum = 0;
            for (int i = 0; i < c.Count; i++)
            {
                sum += (double)c[i].Price;
            }

            return "sum: " + sum + ", avg: " + sum / c.Count;
        }

        public List<api_course> last3rec()
        {
            
            List<api_course> c = GetAllCourse();
            c = c.OrderBy(q => q.CourseId).ToList();
            List<api_course> cc = new List<api_course>();

            cc.Add(c[c.Count - 1]);
            cc.Add(c[c.Count - 2]);
            cc.Add(c[c.Count - 3]);

            return cc.ToList();

        }

        public List<api_course> orderbydescning()
        {
            List<api_course> c = GetAllCourse();
            c = c.OrderByDescending(q => q.CourseId).ToList();

            return c.ToList();
        }

        public List<api_course> InsertCourseList(api_course[] course)
        {
            for (int i = 0; i < course.Length; i++)
            {
                InsertCourse(course[i]);
            }

            return course.ToList();
        }

        public List<api_course> filter(char c)
        {
            List<api_course> cc = GetAllCourse();
            List<api_course> ccc = new List<api_course>();
            for (int i = 0; i < cc.Count; i++)
            {
                for (int k = 0; k < cc[i].Coursename.Length; k++)
                {
                    if (cc[i].Coursename[k] == c)
                    {
                        ccc.Add(cc[i]);
                        break;
                    }

                }
            }
            return ccc.ToList();


        }
    }
}
