using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores.Provider
{
    public abstract class AbstractDatabaseProvider
    {
        public abstract Database connectMySQL(string server, string uid, string pwd, string database);
    }
}
