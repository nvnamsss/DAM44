using DAM.Cores.Connection;
using DAM.Cores.DbObject;
using DAM.Cores.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores
{
    public class Database : IQuery
    {
        public IConnection Connection { get; }
        public T Execute<T>(string query, params object[] args)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }

            throw new NotImplementedException();
        }

        public int Execute(string query, params object[] args)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }

        public IDbObject Sum<TSource>(IEnumerable<TSource> source)
        {
            throw new NotImplementedException();
        }

        public IDbObject Where()
        {
            throw new NotImplementedException();
        }

        public IDbObject Where<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
