using System;
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
            command.Connection = connection._connection;    
            command.CommandText = "SELECT * FROM db";
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader[0] + " -- " + reader[1]);
            }
            reader.Close();

            Cores.Database db = new Cores.Database();
            db.Students.Insert(null);
            QuitEvent.WaitOne();
        }

    }
}
