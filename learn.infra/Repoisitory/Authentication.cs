using Dapper;
using learn.core.Data;
using learn.core.domain;
using learn.core.Repoisitory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace learn.infra.Repoisitory
{
    public class Authentication : IAuthentication
    {
        private readonly IDBContext dBContext;

        public Authentication(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public api_loginAuth Auth(api_loginAuth api_LoginAuth)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("uuserName", api_LoginAuth.userName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("pppassword", api_LoginAuth.Ppassword, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<api_loginAuth> result = dBContext.dbConnection.Query<api_loginAuth>
                 ("api_loginAuth_package.Auth", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void UpdateVerificationCode(api_loginAuth api_LoginAuth)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("LLoginId", api_LoginAuth.LoginId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("vverificationCode", api_LoginAuth.verificationCode.ToString(), dbType: DbType.String, direction: ParameterDirection.Input);

                dBContext.dbConnection.ExecuteAsync
                 ("api_loginAuth_package.UpdateVerificationCode", parameter, commandType: CommandType.StoredProcedure);

            

        }
    }
}
