using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores.DbObject
{
    public class TableObject : IDbObject
    {
        public Database Database { get; set; }

        public void Insert()
        {

        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }

}
