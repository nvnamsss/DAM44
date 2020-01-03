using DAM.Cores.Connection;
using DAM.Cores.Objects;
using DAM.Cores.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores
{
    public class Database : IQuery
    {
        public DbConnection Connection { get; }
        public TableObject Students;
        public Dictionary<string, TableObject> Tables { get; }

        public Database()
        {
            Tables = new Dictionary<string, TableObject>();
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
