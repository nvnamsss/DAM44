using DAM.Cores;
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

            MySQL.MySQLConnection connection = new MySQL.MySQLConnection(server, username, password, database);
            connection.Connect();
            MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand();
            command.Connection = connection.connection;

            command.CommandText = "SELECT * FROM global_priv";

            TestDatabase db = new TestDatabase();
            db.Test(connection);
            TestTable table = new TestTable();
            //table.TestInsert(connection);
            table.TestUpdate(connection);
            //table.TestDelete(connection);
            table.TestSelect(connection);
            table.TestDeserialize(connection);
            //row.name = "abc";
            //row.host = "local";
            //row.port = 3000;
            //row.Update();
            QuitEvent.WaitOne();
        }

    }
}
