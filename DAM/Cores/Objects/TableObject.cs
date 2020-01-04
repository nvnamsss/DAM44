using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores.Objects
{
    public class TableObject : DbObject
    {
        protected List<RowObject> Rows { get; }
        public TableObject()
        {
            Rows = new List<RowObject>();
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
            Console.WriteLine(update);

            Connection.Execute(update);
        }


        public int Insert(RowObject row)
        {
            if (Connection == null)
            {
                throw new Exception("Connection is null");
            }

            if (Connection.ConnectionState == Cores.Connection.ConnectionState.Closed)
            {
                throw new Exception("Connection is closed");
            }

            StringBuilder command = new StringBuilder();
            string fields = string.Empty;
            string values = string.Empty;
            foreach (var entry in row.Fields)
            {
                fields += entry.Key + ",";
                if (entry.Value is string)
                {
                    values += "\"" + entry.Value + "\"" + ",";
                }
                else
                {
                    values += entry.Value + ",";
                }
            }
            fields = fields.Remove(fields.LastIndexOf(","));
            values = values.Remove(values.LastIndexOf(","));
            command.Append("INSERT INTO ");
            command.Append(Name);
            command.AppendLine("(" + fields + ") ");
            command.Append("VALUES (" + values + ")");
            Console.WriteLine("Command:"+command);

            int affected = Connection.Execute(command.ToString());

            if (affected > 0)
            {
                Rows.Add(row);
                row.Parent = this;
            }

            return affected;
        }

        public int Delete(RowObject row)
        {
            StringBuilder command = new StringBuilder();
            int affected = Connection.Execute(command.ToString());

            if (affected > 0)
            {
                Rows.Remove(row);
            }

            return affected;
        }

    }
}
