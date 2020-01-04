using DAM.Cores.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores.Objects
{
    public abstract class DbObject : IDbObject
    {
        [System.ComponentModel.Description]
        public string Name { get; set; }
        public Database Database { get; set; }
        protected DbObject Parent { get; set; }
        public virtual T Deserialize<T>() where T: new()
        {
            T obj = new T();


            return obj;
        }

        public abstract string GetProperties();

        protected static T GetObject<T>() where T : new()
        {
            return new T();
        }
    }
}
