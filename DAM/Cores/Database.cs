using DAM.Cores.Connection;
using DAM.Cores.DbObject;
using DAM.Cores.Query;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores
{
    public abstract class Database : IConnection, IQuery
    {
        protected System.Data.Common.DbConnection _connection;
        protected System.Data.Common.DbCommand _command;

        public ConnectionState ConnectionState => throw new NotImplementedException();

        public event OnConnectHandler OnConnect;
        public event OnErrorHandler OnError;
        public event OnConnectHandler OnDisconnect;
        public event StateChangeHandler StateChanged;

        public abstract void Connect(string url);

        public abstract void Disconnect();

        public abstract void Insert(string table, string id, object data);


        public abstract IDbObject Sum<TSource>(IEnumerable<TSource> source);


        public abstract IDbObject Where();


        public abstract IDbObject Where<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate);
      

        //public IConnection Connection { get; }

        //public abstract void Insert(string table, string id, object data);

        //public IDbObject Sum<TSource>(IEnumerable<TSource> source)
        //{
        //    throw new NotImplementedException();
        //}

        //public IDbObject Where()
        //{
        //    throw new NotImplementedException();
        //}

        //public IDbObject Where<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
