using DataAccessLayer.DataRowMapper;
using DataAccessLayer.Models;
using Spring.Data.Common;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserRepository : AdoDaoSupport
    {
        public UserModel GetUser(string userId)
        {
            IDbParametersBuilder builder = CreateDbParametersBuilder();
            builder.Create().Name("USER_ID").Type(DbType.String).Size(100).Value(userId);

            var rowCallback = new UserRowMapCallback();

            AdoTemplate.QueryWithRowCallback(CommandType.StoredProcedure, "USP_TB_ADM_USER_SELECT", rowCallback, builder.GetParameters());

            return rowCallback.UserInfo;
        }

        public int InsertUser(UserModel user)
        {
            IDbParametersBuilder builder = CreateDbParametersBuilder();
            builder.Create().Name("USER_ID").Type(DbType.String).Size(100).Value(user.UserId);
            builder.Create().Name("PASSWD").Type(DbType.String).Size(500).Value(user.Password);
            builder.Create().Name("NICKNM").Type(DbType.String).Size(50).Value(user.NickName);

            return AdoTemplate.ExecuteNonQuery(CommandType.StoredProcedure, "USP_TB_ADM_USER_INSERT", builder.GetParameters());
        }

        public UserModel GetLoginUser(string userId, string password)
        {
            IDbParametersBuilder builder = CreateDbParametersBuilder();
            builder.Create().Name("USER_ID").Type(DbType.String).Size(100).Value(userId);
            builder.Create().Name("PASSWD").Type(DbType.String).Size(500).Value(password);
            
            var rowCallback = new UserRowMapCallback();
            AdoTemplate.QueryWithRowCallback(CommandType.StoredProcedure, "USP_TB_ADM_USER_SELECT_LOGIN", rowCallback, builder.GetParameters());
            return rowCallback.UserInfo;
        }
    }
}
