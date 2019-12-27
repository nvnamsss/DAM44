using DAM.Cores.Connection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.MySQL
{
    public class MySQLConnection : DbConnection
    {
        private MySqlConnection _connection;
        public MySQLConnection(string server, string username, string password, string database)
        {
            connectionString = new StringBuilder();
            connectionString.Append("server=" + server + ";");
            connectionString.Append("uid=" + username + ";");
            connectionString.Append("pwd=" + password + ";");
            connectionString.Append("database=" + database);
            _connection = new MySqlConnection(connectionString.ToString());
        }

        public override void Connect(string url)
        {
            _connection.ConnectionString = url;
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
