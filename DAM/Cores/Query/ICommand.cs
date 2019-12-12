using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores.Query
{
    public interface ICommand
    {
        /// <summary>
        /// Execute a non-query then return the number of affected rows
        /// </summary>
        /// <param name="query"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        int Execute(string query, params object[] args);
        /// <summary>
        /// Execute a query then return the result as an object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        T Execute<T>(string query, params object[] args);
    }
}
