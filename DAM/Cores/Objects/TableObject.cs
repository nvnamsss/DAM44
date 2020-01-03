using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores.Objects
{
    public class TableObject : IDbObject
    {
        public string Name { get; set; }
        public Database Database { get; set; }

        public void Insert(ColumnObject column)
        {
            if (Database.Connection == null)
            {
                throw new Exception("Connection is null");
            }

            if (Database.Connection.ConnectionState == Connection.ConnectionState.Closed)
            {
                throw new Exception("Connection is closed");
            }

            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO");
            query.Append();
            Database.Connection.SendRequest(query);
        }

        
    }
}
