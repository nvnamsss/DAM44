using DAM.Cores;
using DAM.Cores.Connection;
using DAM.Cores.DbObject;
using DAM.Cores.Query;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.MySQL
{
    class MySQL : Database
    {
        public ConnectionState ConnectionState => throw new NotImplementedException();
        public event OnConnectHandler OnConnect;
        public event OnErrorHandler OnError;
        public event OnConnectHandler OnDisconnect;
        public event StateChangeHandler StateChanged;

        public MySQL(string server, string username, string pwd, string database)
           : base(server, username, pwd, database) { }
        

        public override void Connect()
        {
            _connection = new MySqlConnection("server=localhost;uid=root;pwd=;database=dam");
            _connection.Open();

            _command = new MySqlCommand();
            _command.Connection = _connection;
        }

        public override void Disconnect()
        {
            throw new NotImplementedException();
        }

        public override void Insert(string table, object data)
        {
            string query = "INSERT INTO dam_table values (123, 'asd')";
            _command.CommandText = query;
            _command.ExecuteReader();
        }

        //public override IDbObject Sum<TSource>(IEnumerable<TSource> source)
        //{
        //    throw new NotImplementedException();
        //}

        //public override IDbObject Where()
        //{
        //    throw new NotImplementedException();
        //}

        //public override IDbObject Where<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
