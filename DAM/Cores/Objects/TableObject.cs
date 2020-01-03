using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores.Objects
{
    public class TableObject : DbObject
    {
        
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
            query.Append("INSERT INTO ");
            query.Append(Name);
            Database.Connection.SendRequest(query);
        }

        
    }
}
