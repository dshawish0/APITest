using learn.core.Data;
using learn.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Repoisitory
{
    public interface ITask
    {
        public List<api_task> GetAllTasks();
        public api_task InsertTask(api_task task);
        public bool DeleteTask(int ttaskid);
        public api_task UpdateTask(api_task task);
        public List<empTask_dto> empTaskDto();
        public List<api_task> getTaskByID(int ttaskId);
        public List<Task_dto> numOfTaskEechEmp();
    }
}
