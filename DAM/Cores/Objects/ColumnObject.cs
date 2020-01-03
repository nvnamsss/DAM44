using DAM.Cores.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores.Objects
{
    public class ColumnObject : DbObject
    {
        public void Update()
        {

        }

        public void Delete()
        {

        }

        public override string GetProperties()
        {
            string query = string.Empty;

            query += "(";
            System.Reflection.PropertyInfo[] properties = GetType().GetProperties();
            for (int loop = 0; loop < properties.Length; loop++)
            {
                object[] attrs = properties[loop].GetCustomAttributes(true);

                foreach (object item in attrs)
                {
                    if (item is ColumnAttribute column)
                    {
                        query += column.Name + ",";
                    }
                }
            }

            query += ")";
            return query;
        }
    }
}
