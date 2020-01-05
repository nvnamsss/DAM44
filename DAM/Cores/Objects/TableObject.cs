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
            Query = Cores.Query.TableQuery.Instance;
        }

        public void Update<T>(T originalObj, T newObj)
        {
            string update = string.Empty;
            Dictionary<string, object> originalFields = RowObject.GetFields(originalObj);
            Dictionary<string, object> newFields = RowObject.GetFields(newObj);

            update += "UPDATE " + Name + " ";
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

        public int Update(RowObject original, RowObject current)
        {
            if (Connection == null)
            {
                throw new Exception("Connection is null");
            }

            if (Connection.ConnectionState == Cores.Connection.ConnectionState.Closed)
            {
                throw new Exception("Connection is closed");
            }

            string update = Query.Update(this, original, current);
            int affected = Connection.Execute(update);

            return affected;
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
            string command = Query.Insert(this, row);

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

        public override DbObject Clone()
        {
            throw new NotImplementedException();
        }
    }
}
