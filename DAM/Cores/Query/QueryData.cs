using DAM.Cores.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores.Query
{
    public class QueryData
    {
        public int RowCount
        {
            get
            {
                return _results.Count;
            }
        }
        private List<RowObject> _results;
        //private Dictionary<string, List<object>> _results;
        public QueryData()
        {
            _results = new List<RowObject>();
            //_results = new Dictionary<string, List<object>>();
        }

        public RowObject this[int index]
        {
            get
            {
                if (index > RowCount - 1 || index < 0)
                {
                    return null;
                }

                return _results[index];
            }
        }

        public void Add(RowObject row)
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
