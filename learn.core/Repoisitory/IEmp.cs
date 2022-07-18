using learn.core.Data;
using learn.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Repoisitory
{
    public interface IEmp
    {
        public List<api_emp> GetAllEmp();
        public object InsertEmp(api_emp emp);
        public bool DeleteEmp(int eempId);
        public object UpdateEmp(api_emp emp);
        public List<emp_dto> GetDto();
        public int numOfEmp();
        public double sumOfSalary();
        public double avgOfSalaray();
        public List<api_emp> filterName(char c);
        public string GetAll();
        public List<api_emp> get16names();
        public List<dep_dto> numOfEmpInEachDep();
    }
}
