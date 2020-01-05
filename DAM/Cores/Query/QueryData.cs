using DAM.Cores.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores.Query
{
    public class QueryData
    {
        public int Affected
        {
            get
            {
                return _results.Count;
            }
        }
        private List<DbObject> _results;
        //private Dictionary<string, List<object>> _results;
        public QueryData()
        {
            _results = new List<DbObject>();
            //_results = new Dictionary<string, List<object>>();
        }

        public DbObject this[int index]
        {
            get
            {
                if (index > Affected - 1 || index < 0)
                {
                    return null;
                }

                return _results[index];
            }
        }

        public void Add(DbObject row)
        {
            _results.Add(row);
        }
    }

    public enum ExecuteType
    {
        Scalar,
        Reader,
        NonQuery,
    }
}
