using DAM.Cores.Connection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAM.MySQL
{
    public class MySQLConnection : DbConnection
    {
        public MySQLConnection(string server, string username, string password, string database)
        {
            connectionString = new StringBuilder();
            connectionString.Append("server=" + server + ";");
            connectionString.Append("uid=" + username + ";");
            connectionString.Append("pwd=" + password + ";");
            connectionString.Append("database=" + database);
            _connection = new MySqlConnection(connectionString.ToString());
            _command = new MySqlCommand();
            _command.Connection = _connection;
        }

        public override void Connect(string url)
        {
            try
            {
                _connection.ConnectionString = url;
                _connection.Open();
            }
            catch (Exception e)
            {
                OnErrorInvoke(e);
            }
        }

        public override void Connect()
        {
            try
            {
                _connection.Open();
            }
            catch (Exception e)
            {
                OnErrorInvoke(e);
            }
        }

        public override void Disconnect()
        {
            _connection.Close();
        }
    }
}
