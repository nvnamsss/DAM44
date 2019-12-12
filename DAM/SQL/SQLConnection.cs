using DAM.Cores.Connection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAM.SQL
{
    public class SQLConnection : DbConnection
    {
        private SqlConnection _connection;
        public override void Connect(string url)
        {
            string connectionString = "Data Source=(local);Initial Catalog=Northwind;"
            + "Integrated Security=true";
            _connection = new SqlConnection(connectionString);
        }

        public override void Disconnect()
        {
        }
    }
}
