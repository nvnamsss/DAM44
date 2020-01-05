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

            table.Update(original, current);
        }
    }

}
