using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores.Objects
{
    public interface IDbObject
    {
        string Name { get; set; }
        Database Database { get; set; }
    }
}
