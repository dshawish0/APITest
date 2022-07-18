using learn.core.Data;
using learn.core.DTO;
using learn.core.Repoisitory;
using learn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.Service
{
    public class TaskService : ITaskService
    {
        private readonly ITask api_taskrepoisitory;
        public TaskService(ITask api_taskrepoisitory)
        {
            this.api_taskrepoisitory = api_taskrepoisitory;
        }
        public bool DeleteTask(int ttaskid)
        {
            throw new NotImplementedException();
        }

        public List<empTask_dto> empTaskDto()
        {
            return api_taskrepoisitory.empTaskDto();
        }

        public List<api_task> GetAllTasks()
        {
            return api_taskrepoisitory.GetAllTasks();
        }

        public List<api_task> getTaskByID(int ttaskId)
        {
            return api_taskrepoisitory.getTaskByID(ttaskId);
        }

        public api_task InsertTask(api_task task)
        {
            return api_taskrepoisitory.InsertTask(task);
        }

        public List<Task_dto> numOfTaskEechEmp()
        {
            return api_taskrepoisitory.numOfTaskEechEmp();
        }

        public api_task UpdateTask(api_task task)
        {
            throw new NotImplementedException();
        }
    }
}
