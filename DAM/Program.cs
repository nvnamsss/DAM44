using DAM.Cores;
using DAM.Cores.Provider;
using System;
using System.Linq;
using System.Threading;

namespace DAM
{
    public class student
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    class Program
    {
        public static ManualResetEvent QuitEvent = new ManualResetEvent(false);
        static WindowExitSignal WindowExitSignal;


        static void Main(string[] args)
        {
            student Student = new student();
            Student.id = 1;
            Student.name = "Nguyen";
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

            MySQL.MySQLConnection mysql = new MySQL.MySQLConnection(server, username, password, database);
            MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand();

            AbstractDatabaseProvider databaseProvider = new MySqlProvider();
            Database mysqlDatabase = databaseProvider.connectMySQL("127.0.0.1", "root", "", "database");

            mysqlDatabase.Insert("table", "id", Student);

         
            //mysql.Connect();
            //command.Connection = mysql._connection;    
            //command.CommandText = "SELECT * FROM db";

            //var reader = command.ExecuteReader();

            //while (reader.Read())
            //{
            //    Console.WriteLine(reader[0] + " -- " + reader[1]);
            //}
            //reader.Close();
            QuitEvent.WaitOne();
        }

    }
}

//Select (id, hoten) from Student where student.id == 3 or student.diem == 10 
