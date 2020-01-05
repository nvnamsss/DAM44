using DAM.Cores.Attributes;
using DAM.Cores.Connection;
using DAM.Cores.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM
{
    public class TestRow
    {
        [Column("Server_name")]
        public string name { get; set; }

        [Column("Host")]
        public string host { get; set; }
        [Column("Port")]
        public int port { get; set; }

        public TestRow()
        {

        }

        public void Test(DbConnection connection)
        {
            RowObject row = new RowObject();
            row.Fields.Add("Server_name", "123");
            row.Fields.Add("Host", "localhost");
            row.Fields.Add("Port", 1900);

            TestRow test = row.Deserialize<TestRow>();
            Console.WriteLine("[TestRow] - " + test);

            TableObject table = new TableObject();
            table.Name = "servers";
            table.Connection = connection;
            table.Insert(row);
        }

        public override string ToString()
        {
            string s = string.Empty;
            s += "Servername: " + name;
            s += "Host: " + host;
            s += "Port: " + port;

            return s;
        }
    }

}
