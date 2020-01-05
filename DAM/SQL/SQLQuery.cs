using DAM.Cores.Objects;
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
