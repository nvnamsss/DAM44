using DAM.Cores.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores.Query
{
    public abstract class QueryGenerator
    {
        public abstract string Insert(DbObject target, DbObject source);
        public abstract string Update(DbObject target, DbObject original, DbObject current);
        public abstract string Delete(DbObject target, DbObject source);
        public abstract string Select(DbObject target, DbObject source);
    }
}
