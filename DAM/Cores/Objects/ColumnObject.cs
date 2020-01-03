using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores.Objects
{
    public class ColumnObject : IDbObject
    {
        public Database Database { get; set; }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Update()
        {

        }

        public void Delete()
        {

        }
    }
}
