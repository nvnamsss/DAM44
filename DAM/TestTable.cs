using DAM.Cores.Connection;
using DAM.Cores.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM
{
    public class TestTable
    {
        public TestTable()
        {

        }


        public void TestInsert(DbConnection connection)
        {
            TableObject table = new TableObject();
            table.Name = "servers";
            table.Connection = connection;

            RowObject row = new RowObject();
            row.Fields.Add("Server_name", "testinsert");
            row.Fields.Add("Host", "localhost");
            row.Fields.Add("Port", 3000);

            table.Insert(row);
        }

        public void TestUpdate(DbConnection connection)
        {
            TableObject table = new TableObject();
            table.Name = "servers";
            table.Connection = connection;

            RowObject original = new RowObject();
            //row.Fields.Add("Server_name", "123");
            original.Fields.Add("Host", "localhost");
            original.Fields.Add("Port", 1900);

            RowObject current = (RowObject)original.Clone();
            current.Fields.Add("Server_name", "123");

            int affected = table.Update(original, current);
            Console.WriteLine("[TestUpdate] - " + affected + " Row(s) is affected");
        }

        public void TestDelete(DbConnection connection)
        {
            TableObject table = new TableObject();
            table.Name = "servers";
            table.Connection = connection;

            RowObject row = new RowObject();
            row.Fields.Add("Server_name", "123");

            int affected = table.Delete(row);
            Console.WriteLine("[TestDelete] - " + affected + " Row(s) is affected");
        }

        public void TestSelect(DbConnection connection)
        {
            TableObject table = new TableObject();
            table.Name = "servers";
            table.Connection = connection;

            RowObject row = new RowObject();
            row.Fields.Add("Server_name", "testinsert");
            var rows = table.Select(row);

            foreach (var item in rows)
            {
                Console.WriteLine("[TestSelect] - " + item);
            }
        }
    }

}
