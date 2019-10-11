using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace HC.Core.Services
{
    public class DataBaseFactory
    {
        public SqlSugarClient DB { get; set; }


        public SqlSugarClient GetDB(string connStr) => new SqlSugarClient(new ConnectionConfig
        {
            ConnectionString = connStr,
            DbType = DbType.SqlServer,
            IsAutoCloseConnection = true,
            InitKeyType = InitKeyType.Attribute
        });
    }
}
