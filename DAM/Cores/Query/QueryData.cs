using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores.Query
{
    public class QueryData
    {
        private Dictionary<string, List<object>> _results;
        public QueryData()
        {
            _results = new Dictionary<string, List<object>>();
        }

        public List<object> this[string field]
        {
            get
            {
                if (_results.ContainsKey(field))
                {
                    return _results[field];
                }

                return new List<object>();
            }
        }

        public void Add(string field, object value)
        {
            if (!_results.ContainsKey(field))
            {
                _results.Add(field, new List<object>());
            }

            _results[field].Add(value);
        }
    }

    public enum ExecuteType
    {
        Scalar,
        Reader,
        NonQuery,
    }
}
