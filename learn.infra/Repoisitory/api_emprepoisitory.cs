using Dapper;
using learn.core.Data;
using learn.core.domain;
using learn.core.DTO;
using learn.core.Repoisitory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace learn.infra.Repoisitory
{
    public class api_emprepoisitory : IEmp
    {
        private readonly IDBContext dBContext;

        public api_emprepoisitory(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public double avgOfSalaray()
        {
            return sumOfSalary()/ numOfEmp();
        }

        public bool DeleteEmp(int eempId)
        {
            var parameter = new DynamicParameters();
            parameter.Add
               ("crud", "Del", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("eempId", eempId, dbType: DbType.Int32, direction: ParameterDirection.Input);
               var result= dBContext.dbConnection.ExecuteAsync
                ("API_empCRUD_Package.empCRUD", parameter, commandType: CommandType.StoredProcedure);
           
            if (result == null)
                return false;
            return true;
        }

        public List<api_emp> filterName(char c)
        {
            return GetAllEmp().ToList().Where(emp => emp.Fname.Contains(c) && emp.Lname.Contains(c)).ToList();
        }

        public string GetAll()
        {
            return "numOfEmp "+ numOfEmp() + "  sumOfSalary " + sumOfSalary() + "  avgOfSalaray " + avgOfSalaray();
        }

        public List<api_emp> GetAllEmp()
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("crud", "Get", dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<api_emp> result = dBContext.dbConnection.Query<api_emp>
                ("API_empCRUD_Package.empCRUD", parameter, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public List<emp_dto> GetDto()
        {
            IEnumerable<emp_dto> result = dBContext.dbConnection.Query<emp_dto>
               ("API_empCRUD_Package.GetDto", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public object InsertEmp(api_emp emp)
        {
            if (!isEmail(emp.email))
                return "InValidEmail";
            var parameter = new DynamicParameters();
            parameter.Add
                ("crud", "Cre", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
              ("FFname", emp.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
             ("LLname", emp.Lname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("ssalary", emp.salary, dbType: DbType.Double, direction: ParameterDirection.Input);
            parameter.Add
               ("ddepId", emp.depId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
              ("eemail", emp.email, dbType: DbType.String, direction: ParameterDirection.Input);

            dBContext.dbConnection.ExecuteAsync
                ("API_empCRUD_Package.empCRUD", parameter, commandType: CommandType.StoredProcedure);

            return emp;
        }

        public int numOfEmp()
        {
            return GetAllEmp().ToList().Count;
        }

        public double sumOfSalary()
        {
            return GetAllEmp().ToList().Sum(emp => emp.salary);
        }

        public object UpdateEmp(api_emp emp)
        {
            if (!isEmail(emp.email))
                return "InValidEmail";

            var parameter = new DynamicParameters();
            parameter.Add
                ("crud", "Upd", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
             ("eempId", emp.empId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
              ("FFname", emp.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
             ("LLname", emp.Lname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("ssalary", emp.salary, dbType: DbType.Double, direction: ParameterDirection.Input);
            parameter.Add
               ("ddepId", emp.depId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
            ("eemail", emp.email, dbType: DbType.String, direction: ParameterDirection.Input);

            dBContext.dbConnection.ExecuteAsync
               ("API_empCRUD_Package.empCRUD", parameter, commandType: CommandType.StoredProcedure);

            return emp;
        }

        public bool isEmail(string email)
        {
            return Regex.IsMatch(email, 
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", 
                RegexOptions.IgnoreCase);

        }

        public List<api_emp> get16names()
        {
            return GetAllEmp().ToList().Where(emp => emp.email.Contains(".com") ).ToList();
        }

        public List<dep_dto> numOfEmpInEachDep()
        {
            IEnumerable<dep_dto> result = dBContext.dbConnection.Query<dep_dto>
               ("API_empCRUD_Package.numOfEmpInEachDep", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
    }
}
