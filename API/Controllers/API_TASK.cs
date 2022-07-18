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
    public class API_TASK : ControllerBase
    {
        private readonly ITaskService TaskService;

        public API_TASK(ITaskService TaskService)
        {
            this.TaskService = TaskService;
        }

        [HttpGet]
        public IActionResult GetAllEmp()
        {
            try
            {
                return Ok(TaskService.GetAllTasks());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public IActionResult InsertEmp([FromBody] api_task task)
        {
            try
            {
                return Ok(TaskService.InsertTask(task));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [Route("get")]
        public IActionResult empTaskDto()
        {
            try
            {
                return Ok(TaskService.empTaskDto());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("getTaskById/{ttaskId}")]
        public IActionResult getTaskById(int ttaskId)
        {
            try
            {
                return Ok(TaskService.getTaskByID(ttaskId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("numOfTaskEechEmp")]
        public IActionResult numOfTaskEechEmp()
        {
            try
            {
                return Ok(TaskService.numOfTaskEechEmp());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //

    }
}
