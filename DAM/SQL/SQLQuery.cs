using DAM.Cores.DbObject;
using DAM.Cores.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.SQL
{
    public class SQLQuery : IQuery
    {
        public SQLQuery()
        {

        }

        public void Insert(string table, string id, object data)
        {
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
