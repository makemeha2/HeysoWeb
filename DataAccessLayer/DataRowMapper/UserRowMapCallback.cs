using DataAccessLayer.Models;
using Spring.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataRowMapper
{
    public class UserRowMapCallback : IRowCallback
    {
        public UserModel UserInfo { get; set; }

        public void ProcessRow(IDataReader reader)
        {
            UserInfo = new UserModel
            {
                UserId = reader["USER_ID"].ToString(),
                //Password = reader["PASSWD"] == DBNull.Value ? string.Empty : reader["PASSWD"].ToString(),
                NickName = reader["NICKNM"].ToString(),
                CreateDate = reader["CREATE_DT"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["CREATE_DT"]),
                UpdateDate = reader["UPDATE_DT"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["UPDATE_DT"])
            };
        }
    }
}
