using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores.Objects
{
    public class TableObject : DbObject
    {
        public List<RowObject> Rows { get; }
        public TableObject()
        {

        }

        public void Update<T>(T originalObj, T newObj)
        {
            string update = string.Empty;
            Dictionary<string, object> originalFields = RowObject.GetFields(originalObj);
            Dictionary<string, object> newFields = RowObject.GetFields(newObj);

            //update += "UPDATE " + Parent.Name + " ";
            update += "SET ";
            foreach (var entry in newFields)
            {
                update += entry.Key + "=" + entry.Value + ",";
            }
            update = update.Remove(update.LastIndexOf(","));
            update += " " + "WHERE" + " ";

            foreach (var entry in originalFields)
            {
                update += entry.Key + "=" + entry.Value + " AND ";
            }
            update = update.Remove(update.LastIndexOf("AND"));

            Connection.Execute(update);
            Console.WriteLine(update);
        }


        public void Insert(RowObject row)
        {
            if (Connection == null)
            {
                throw new Exception("Connection is null");
            }

            if (Connection.ConnectionState == Cores.Connection.ConnectionState.Closed)
            {
                throw new Exception("Connection is closed");
            }

            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO ");
            query.Append(Name);
            query.Append(row.ToString());

            Connection.Query(query.ToString());
        }

        
    }
}
