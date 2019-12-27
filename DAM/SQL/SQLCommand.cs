using DAM.Cores.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.SQL
{
    public class SQLCommand : ICommand
    {
        SQLConnection Connection;
        public int Execute(string query, params object[] args)
        {
            throw new NotImplementedException();
        }

        public T Execute<T>(string query, params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
