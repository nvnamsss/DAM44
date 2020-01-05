using DAM.Cores.Connection;
using DAM.Cores.Objects;
using DAM.Cores.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores
{
    public class Database
    {
        public DbConnection Connection { get; }
        public Dictionary<string, TableObject> Tables { get; }

        public Database(DbConnection connection)
        {
            Connection = connection;

            string command = "SHOW TABLES";
            Tables = new Dictionary<string, TableObject>();
            QueryData data = Connection.Query(command);
            for (int loop = 0; loop < data.Affected; loop++)
            {

                foreach (var entry in data[loop].Data)
                {
                    TableObject table = new TableObject();
                    table.Name = entry.Value.ToString();
                    Tables.Add(table.Name, table);
                }
            }

        }
        
    }
}
