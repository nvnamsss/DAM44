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

            TestRow row = new TestRow();
            row.name = "abc";
            row.host = "local";
            row.port = 3000;
            row.Update();
            QuitEvent.WaitOne();
        }

    }
}
