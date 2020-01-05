using DAM.Cores.Attributes;
using DAM.Cores.Connection;
using DAM.Cores.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores.Objects
{
    public abstract class DbObject : IDbObject, IDbClone
    {
        public string Name { get; set; }
        public DbObject Parent { get; set; }

        public DbConnection Connection { get; set; }
        public Dictionary<string, object> Data { get; set; } = new Dictionary<string, object>();
        protected QueryGenerator Query { get; set; }

        public abstract DbObject Clone();

        public virtual T Deserialize<T>() where T: new()
        {
            T obj = new T();
            return obj;
        }

        public override string ToString()
        {
            string s = string.Empty;

            foreach (var entry in Data)
            {
                s = s + entry.Value + ": " + entry.Key + Environment.NewLine;
            }

            return s;
        }
    }
}
