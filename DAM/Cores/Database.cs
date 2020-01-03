using DAM.Cores.Connection;
using DAM.Cores.DbObject;
using DAM.Cores.Query;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores
{
    public abstract class Database
    {
        protected System.Data.Common.DbConnection _connection;
        protected System.Data.Common.DbCommand _command;
        protected string host;
        protected string username;
        protected string pwd;
        protected string database;

        public Database(string host, string username, string pwd, string database)
        {
            this.host = host;
            this.username = username;
            this.pwd = pwd;
            this.database = database;
        }

        public abstract void Connect();
        public abstract void Disconnect();
        public abstract void Insert(string table, object data);

    }
}
