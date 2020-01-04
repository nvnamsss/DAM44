using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores.Objects
{
    public class TableObject : DbObject
    {
        public Database Database
        {
            get
            {
                return Parent as Database;
            }
        }
        public TableObject()
        {

        }

        public void Update(object originalObj, object newObj)
        {
            string update = string.Empty;
            Dictionary<string, string> originalFields = RowObject.GetFields(newObj);
            Dictionary<string, string> newFields = RowObject.GetFields(newObj);

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
            
            Console.WriteLine(update);
        }

        public override string GetProperties()
        {
            throw new NotImplementedException();
        }

        public void Insert(RowObject row)
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
            query.Append(row.ToString());

            Database.Connection.SendRequest(query.ToString());
        }

        
    }
}
