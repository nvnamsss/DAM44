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
        public SQLConnection(string server, string username, string password, string database)
        {
            connectionString = new StringBuilder();
            connectionString.Append("uid=" + username);
            connectionString.Append("pwd=" + password);
            connectionString.Append("database=" + database);
            connectionString.Append("server=" + server);
            _connection = new SqlConnection(connectionString.ToString());
        }
        public override void Connect(string url)
        {
            _connection.Open();
        }

        public override void Connect()
        {
            _connection.Open();
        }

        public override void Disconnect()
        {
            _connection.Close();
        }
    }
}
