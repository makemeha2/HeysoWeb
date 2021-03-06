﻿using DataAccessLayer.Models;
using Spring.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataRowMapper
{
    public class QnARowMapCallback : IRowCallback
    {
        public QnAModel UserInfo { get; set; }

        public void ProcessRow(IDataReader reader)
        {
            UserInfo = new QnAModel
            {
                YYYY = reader["YYYY"].ToString(),
                MM = reader["MM"].ToString(),
                DD = reader["DD"].ToString(),
                Question = reader["Question"].ToString(),
                Answer = reader["Answer"] == null ? string.Empty : reader["Answer"].ToString(),
                UserId = reader["UserID"] == null ? string.Empty : reader["UserID"].ToString(),
                UpdateDate = reader["UpdateDate"] == null ? DateTime.MinValue : Convert.ToDateTime(reader["UpdateDate"])
            };
        }
    }
}
