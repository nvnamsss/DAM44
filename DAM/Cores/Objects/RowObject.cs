using DAM.Cores.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores.Objects
{
    public class RowObject : DbObject
    {
        /// <summary>
        /// Determine fields and values of a row
        /// </summary>
        public Dictionary<string, object> Fields { get; set; }
        public RowObject()
        {
            Fields = new Dictionary<string, object>();
        }

        /// <summary>
        /// return a dictionary that contain field name and value
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Dictionary<string, object> GetFields(object obj)
        {
            Dictionary<string, object> fields = new Dictionary<string, object>();

            System.Reflection.PropertyInfo[] properties = obj.GetType().GetProperties();
            for (int loop = 0; loop < properties.Length; loop++)
            {
                object[] attrs = properties[loop].GetCustomAttributes(true);

                foreach (object item in attrs)
                {
                    if (item is ColumnAttribute column)
                    {
                        string property = column.Name;
                        object value = properties[loop].GetValue(obj, null);

                        fields.Add(property, value);
                    }
                }
            }

            return fields;
        }
        
        /// <summary>
        /// return a dictionary that contain field name and property name
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public Dictionary<string, string> GetProperties(object obj)
        {
            Dictionary<string, string> fieldsMap = new Dictionary<string, string>(); 
            System.Reflection.PropertyInfo[] properties = obj.GetType().GetProperties();

            for (int loop = 0; loop < properties.Length; loop++)
            {
                object[] attrs = properties[loop].GetCustomAttributes(true);

                foreach (object item in attrs)
                {
                    if (item is ColumnAttribute column)
                    {
                        fieldsMap.Add(column.Name, properties[loop].Name);
                    }
                }
            }

            return fieldsMap;
        }

        public override T Deserialize<T>()
        {
            T t = base.Deserialize<T>();
            Dictionary<string, string> fields = GetProperties(t);
            foreach (var entry in fields)
            {
                if (Fields.ContainsKey(entry.Key))
                {
                    System.Reflection.PropertyInfo prop = t.GetType().GetProperty(entry.Value);
                  
                    if (prop.CanWrite)
                    {
                        prop.SetValue(t, Fields[entry.Key]);
                    }
                }
            }

            return t;
        }

        public override DbObject Clone()
        {
            RowObject row = (RowObject)MemberwiseClone();
            row.Fields = new Dictionary<string, object>(Fields);
            return row;
        }

        public override string ToString()
        {
            string s = string.Empty;

            foreach (var entry in Fields)
            {
                s = s + entry.Key + ": " + entry.Value + Environment.NewLine;
            }

            return s;
        }
    }
}
