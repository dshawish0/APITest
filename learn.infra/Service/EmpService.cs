using learn.core.Data;
using learn.core.DTO;
using learn.core.Repoisitory;
using learn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.Service
{
    public class EmpService : IEmpService
    {

        private readonly IEmp api_Emprepoisitory;
        public EmpService(IEmp api_Emprepoisitory)
        {
            this.api_Emprepoisitory = api_Emprepoisitory;
        }

        public double avgOfSalaray()
        {
            return api_Emprepoisitory.avgOfSalaray();
        }

        public bool DeleteEmp(int eempId)
        {
            return api_Emprepoisitory.DeleteEmp(eempId);
        }

        public List<api_emp> filterName(char c)
        {
            return api_Emprepoisitory.filterName(c);
        }

        public List<api_emp> get16names()
        {
            return api_Emprepoisitory.get16names();
        }

        public string GetAll()
        {
            return api_Emprepoisitory.GetAll();
        }

        public List<api_emp> GetAllEmp()
        {
            return api_Emprepoisitory.GetAllEmp();
        }

        public List<emp_dto> GetDto()
        {
            return api_Emprepoisitory.GetDto();
        }

        public object InsertEmp(api_emp emp)
        {
            return api_Emprepoisitory.InsertEmp(emp);
        }

        public List<dep_dto> numOfEmpInEachDep()
        {
            return api_Emprepoisitory.numOfEmpInEachDep();
        }

        public int numOfEmp()
        {
            return api_Emprepoisitory.numOfEmp();
        }

        public double sumOfSalary()
        {
            return api_Emprepoisitory.sumOfSalary();
        }

        public object UpdateEmp(api_emp emp)
        {
            return api_Emprepoisitory.UpdateEmp(emp);
        }
    }
}
