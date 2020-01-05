using DAM.Cores;
using DAM.Cores.Connection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM
{
    public class TestDatabase
    {
        public TestDatabase()
        {

        }

        public void Test(DbConnection connection)
        {
            Database db = new Database(connection);
            Console.WriteLine("[TestDatabase] - database include: " + db.Tables.Count);

            foreach (var entry in db.Tables)
            {
                Console.WriteLine(entry.Key);
            }
        }

    }
}
