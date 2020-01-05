using DAM.Cores.Connection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores.Objects
{
    public interface IDbObject
    {
        DbConnection Connection { get; }
        string Name { get; set; }
        T Deserialize<T>() where T : new();
    }
}
