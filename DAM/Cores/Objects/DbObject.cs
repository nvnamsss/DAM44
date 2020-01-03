using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores.Objects
{
    public class DbObject : IDbObject
    {
        public string Name { get; set; }
        public Database Database { get; set; }
    }
}
