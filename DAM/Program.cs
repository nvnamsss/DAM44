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
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                string s = string.Empty;
                s = s + reader["host"] + "-";
                s = s + reader["User"];
                var e = reader.GetEnumerator();
                //foreach (var entry in reader)
                //{
                //    Dictionary<string, string> dic = entry as Dictionary<string, string>;

                //}
                for (int loop = 0; loop < reader.FieldCount; loop++)
                {
                    s = s + reader.GetName(loop) + ":" + reader[loop] + "-";
                }

                Console.WriteLine(s);
            }
            reader.Close();
            TestRow row = new TestRow();
            row.Test(connection);
            //row.name = "abc";
            //row.host = "local";
            //row.port = 3000;
            //row.Update();
            QuitEvent.WaitOne();
        }

    }
}
