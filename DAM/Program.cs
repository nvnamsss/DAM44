using DAM.Cores;
using DAM.Cores.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DAM
{
    class Program
    {
        public static ManualResetEvent QuitEvent = new ManualResetEvent(false);
        static WindowExitSignal WindowExitSignal;
        static void Main(string[] args)
        {
            WindowExitSignal = new WindowExitSignal();
            WindowExitSignal.Exit += () =>
            {
                QuitEvent.Set();
            };

            Console.WriteLine("Hello World!");
            System.Collections.Generic.List<int> i;
            string server = "127.0.0.1";
            string username = "root";
            string password = "";
            string database = "mysql";

            /* Connect to Database */
            MySQL.MySQLConnection connection = new MySQL.MySQLConnection(server, username, password, database);
            connection.Connect();
            //MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand();
            //command.Connection = connection.connection;

            //command.CommandText = "SELECT * FROM global_priv"; 
            Database db = new Database(connection);
            Console.WriteLine("[TestDatabase] - database include: " + db.Tables.Count);

            foreach (var entry in db.Tables)
            {
                Console.WriteLine(entry.Key);
            }
            /* -Connect to Database */

            /* Insert into a table */
            TableObject table = new TableObject();
            table.Name = "servers";
            table.Connection = connection;


            RowObject row = new RowObject();
            row.Fields.Add("Server_name", "testinsert");
            row.Fields.Add("Host", "localhost");
            row.Fields.Add("Port", 3000);

            table.Insert(row);
            /* -Insert into a table */

            /* Select a row */
            row = new RowObject();
            row.Fields.Add("Server_name", "testinsert");
            var rows = table.Select(row);

            foreach (var item in rows)
            {
                Console.WriteLine("[" + table.Name + "]" + " - " + item);
            }
            /* -Select a row */

            /* Deserilize a row from SELECT */
            row = new RowObject();
            row.Fields.Add("host", "localhost");

            IEnumerable<TestRow> t = table.Select<TestRow>(row);
            foreach (var item in t)
            {
                Console.WriteLine("[TestDeserialize] - " + item);
            }
            /* -Deserilize a row from SELECT */

            /* Update a table row */
            RowObject original = new RowObject();
            //row.Fields.Add("Server_name", "123");
            original.Fields.Add("Host", "localhost");
            original.Fields.Add("Port", 3000);

            RowObject current = (RowObject)original.Clone();
            current.Fields.Add("Server_name", "123");

            int affected = table.Update(original, current);
            Console.WriteLine("[" + table.Name + "]" + " - " + affected + " Row(s) is affected");
            /* -Update a table row */

            /* Delete a table row */
            row = new RowObject();
            row.Fields.Add("Server_name", "123");

            affected = table.Delete(row);
            Console.WriteLine("[" + table.Name + "]" + " - " + affected + " Row(s) is affected");
            /* -Delete a table row */

            /* Deserilize a row */
            row = new RowObject();
            row.Fields.Add("Server_name", "123");
            row.Fields.Add("Host", "localhost");
            row.Fields.Add("Port", 1900);

            TestRow deserialized = row.Deserialize<TestRow>();
            Console.WriteLine("[TestRow] - " + deserialized);
            /* -Deserilize a row */

            /* Disconnect */
            connection.Disconnect();
            /* -Disconnect */

            //table.TestInsert(connection);
            //table.TestUpdate(connection);
            //table.TestDelete(connection);
            //table.TestSelect(connection);
            //table.TestDeserialize(connection);
            //row.name = "abc";
            //row.host = "local";
            //row.port = 3000;
            //row.Update();
            QuitEvent.WaitOne();
        }

    }
}
