using DAM.Cores.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores.Objects
{
    public class RowObject : DbObject
    {

        public static Dictionary<string, string> GetFields(object obj)
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();

            System.Reflection.PropertyInfo[] properties = obj.GetType().GetProperties();
            for (int loop = 0; loop < properties.Length; loop++)
            {
                object[] attrs = properties[loop].GetCustomAttributes(true);

                foreach (object item in attrs)
                {
                    if (item is ColumnAttribute column)
                    {
                        string property = column.Name;
                        string value = properties[loop].GetValue(obj, null).ToString();

                        fields.Add(property, value);
                    }
                }
            }

            return fields;
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
