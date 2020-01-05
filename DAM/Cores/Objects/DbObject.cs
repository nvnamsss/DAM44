using DAM.Cores.Attributes;
using DAM.Cores.Connection;
using DAM.Cores.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores.Objects
{
    public abstract class DbObject : IDbObject, IDbPrototype
    {
        public string Name { get; set; }
        public DbObject Parent { get; set; }

        public DbConnection Connection { get; set; }
        protected QueryGenerator Query { get; set; }

        public abstract DbObject Clone();

        public virtual T Deserialize<T>() where T: new()
        {
            T obj = new T();
            return obj;
        }

    }
}
