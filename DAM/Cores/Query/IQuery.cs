using DAM.Cores.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores.Query
{
    public interface IQuery
    {
        IDbObject Where();
        //LinQ Where method, juts an example
        IDbObject Where<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate);
        IDbObject Sum<TSource>(IEnumerable<TSource> source);
    }
}
