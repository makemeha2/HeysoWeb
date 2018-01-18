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
    public class QnARepository : AdoDaoSupport
    {
        public QnAModel GetQnAData(QnAModel paramQnA)
        {
            if (paramQnA == null) throw new Exception("paramQnA의 값이 Null 입니다.");

            IDbParametersBuilder builder = CreateDbParametersBuilder();
            builder.Create().Name("YYYY").Type(DbType.String).Size(4).Value(paramQnA.YYYY);
            builder.Create().Name("MM").Type(DbType.String).Size(2).Value(paramQnA.MM);
            builder.Create().Name("DD").Type(DbType.String).Size(2).Value(paramQnA.DD);
            builder.Create().Name("UserId").Type(DbType.String).Size(100).Value(paramQnA.UserId);

            var rowCallback = new QnARowMapCallback();

            AdoTemplate.QueryWithRowCallback(CommandType.StoredProcedure, "USP_TB_QNA_MASTER_SELECT", rowCallback, builder.GetParameters());

            return rowCallback.UserInfo;
        }

        public int SaveQnAData(QnAModel paramQnA)
        {
            if (paramQnA == null) throw new Exception("paramQnA의 값이 Null 입니다.");

            IDbParametersBuilder builder = CreateDbParametersBuilder();
            builder.Create().Name("YYYY").Type(DbType.String).Size(4).Value(paramQnA.YYYY);
            builder.Create().Name("MM").Type(DbType.String).Size(2).Value(paramQnA.MM);
            builder.Create().Name("DD").Type(DbType.String).Size(2).Value(paramQnA.DD);
            builder.Create().Name("UserId").Type(DbType.String).Size(100).Value(paramQnA.UserId);
            builder.Create().Name("Answer").Type(DbType.String).Size(1000).Value(paramQnA.Answer);

            return AdoTemplate.ExecuteNonQuery(CommandType.StoredProcedure, "USP_TB_ADM_USER_INSERT", builder.GetParameters());
        }
    }
}
