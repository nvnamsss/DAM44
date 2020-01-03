using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores.Provider
{
    public class DatabaseProvider : AbstractDatabaseProvider
    {
        public override Database connectMySQL(string server, string uid, string pwd, string database)
        {
            return new MySQL.MySQL(server, uid, pwd, database);
        }
    }
}
