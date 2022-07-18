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

namespace learn.infra.Repoisitory
{
    public class api_taskrepoisitory : ITask
    {
        private readonly IDBContext dBContext;

        public api_taskrepoisitory(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public bool DeleteTask(int ttaskid)
        {
            throw new NotImplementedException();
        }

        public List<empTask_dto> empTaskDto()
        {
            IEnumerable<empTask_dto> result = dBContext.dbConnection.Query<empTask_dto>
               ("API_TaskCRUD_Package.empTaskDto", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public List<api_task> GetAllTasks()
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("crud", "Get", dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<api_task> result = dBContext.dbConnection.Query<api_task>
                ("API_TaskCRUD_Package.taskCRUD", parameter, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public List<api_task> getTaskByID(int ttaskId)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("ttaskId", ttaskId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<api_task> result = dBContext.dbConnection.Query<api_task>
                ("API_TaskCRUD_Package.getTaskById", parameter, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public api_task InsertTask(api_task task)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("crud", "Cre", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
              ("ttaskName", task.taskName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("eempId", task.empId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dBContext.dbConnection.ExecuteAsync
                ("API_TaskCRUD_Package.taskCRUD", parameter, commandType: CommandType.StoredProcedure);

            return task;
        }

        public List<Task_dto> numOfTaskEechEmp()
        {
            IEnumerable<Task_dto> result = dBContext.dbConnection.Query<Task_dto>
               ("API_TaskCRUD_Package.numOfTaskEechEmp", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public api_task UpdateTask(api_task task)
        {
            throw new NotImplementedException();
        }
    }
}
