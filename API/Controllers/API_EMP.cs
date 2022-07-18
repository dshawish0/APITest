using learn.core.Data;
using learn.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class API_EMP : ControllerBase
    {
        private readonly IEmpService EmpService;

        public API_EMP(IEmpService EmpService)
        {
            this.EmpService = EmpService;
        }

        [HttpGet]
        public IActionResult GetAllEmp()
        {
            try
            {
                return Ok(EmpService.GetAllEmp());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public IActionResult InsertEmp([FromBody] api_emp emp)
        {
            try
            {
                return Ok(EmpService.InsertEmp(emp));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route("updateEmp")]
        public IActionResult updateCourseName([FromBody] api_emp emp)
        {
            try
            {
                return Ok(EmpService.UpdateEmp(emp));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("delete/{EmpId}")]
        public IActionResult DeleteEmp(int EmpId)
        {
            try
            {
                return Ok(EmpService.DeleteEmp(EmpId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("get")]
        public IActionResult GetAllEmpk()
        {
            try
            {
                return Ok(EmpService.GetDto());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("getSumOfSalary")]
        public IActionResult getSumOfSalary()
        {
            try
            {
                return Ok(EmpService.sumOfSalary());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("getNumOfEmp")]
        public IActionResult getNumOfEmp()
        {
            try
            {
                return Ok(EmpService.numOfEmp());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("getAvgOfSalary")]
        public IActionResult getAvgOfSalary()
        {
            try
            {
                return Ok(EmpService.avgOfSalaray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("filterByName/{c}")]
        public IActionResult filterByName(char c)
        {
            try
            {
                return Ok(EmpService.filterName(c));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(EmpService.GetAll());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("get16names")]
        public IActionResult get16names()
        {
            try
            {
                return Ok(EmpService.get16names());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("numOfEmpInEachDep")]
        public IActionResult numOfEmpInEachDep()
        {
            try
            {
                return Ok(EmpService.numOfEmpInEachDep());
            }
            catch(Exception ex)
            {
                throw ex;
            }
            


        }

    }
}
