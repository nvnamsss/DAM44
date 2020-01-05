using DAM.Cores.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores.Query
{
    public class TableQuery : QueryGenerator
    {
        public static readonly TableQuery Instance = new TableQuery();

        public override string Delete(DbObject target, DbObject source)
        {
            StringBuilder command = new StringBuilder();
            RowObject row = source as RowObject;
            string where = string.Empty;

            foreach (var entry in row.Fields)
            {
                if (entry.Value is string)
                {
                    where += entry.Key + "=" + "\"" + entry.Value + "\"" + " AND ";
                }
                else
                {
                    where += entry.Key + "=" + entry.Value + " AND ";
                }
            }
            where = where.Remove(where.LastIndexOf(" AND "));

            command.AppendLine("DELETE FROM " + target.Name);
            command.AppendLine("WHERE " + where);

            return command.ToString();
        }

        public override string Insert(DbObject target, DbObject source)
        {
            RowObject row = source as RowObject;

            StringBuilder command = new StringBuilder();
            string fields = string.Empty;
            string values = string.Empty;
            foreach (var entry in row.Fields)
            {
                fields += entry.Key + ",";
                if (entry.Value is string)
                {
                    values += "\"" + entry.Value + "\"" + ",";
                }
                else
                {
                    values += entry.Value + ",";
                }
            }
            fields = fields.Remove(fields.LastIndexOf(","));
            values = values.Remove(values.LastIndexOf(","));
            command.Append("INSERT INTO ");
            command.Append(target.Name);
            command.AppendLine("(" + fields + ") ");
            command.Append("VALUES (" + values + ")");

            return command.ToString();
        }

        public override string Select(DbObject target, DbObject source)
        {
            StringBuilder command = new StringBuilder();
            RowObject row = source as RowObject;
            string where = string.Empty;

            foreach (var entry in row.Fields)
            {
                if (entry.Value is string)
                {
                    where += entry.Key + "=" + "\"" + entry.Value + "\"" + " AND ";
                }
                else
                {
                    where += entry.Key + "=" + entry.Value + " AND ";
                }
            }
            where = where.Remove(where.LastIndexOf(" AND "));

            command.AppendLine("SELECT * FROM " + target.Name);
            command.AppendLine("WHERE " + where);

            return command.ToString();
        }

        public override string Update(DbObject target, DbObject original, DbObject current)
        {
            StringBuilder command = new StringBuilder();
            RowObject originalRow = original as RowObject;
            RowObject currentRow = current as RowObject;
            string set = string.Empty;
            string where = string.Empty;

            foreach (var entry in currentRow.Fields)
            {
                if (entry.Value is string)
                {
                    set += entry.Key + "=" + "\"" + entry.Value + "\"" + ",";
                }
                else
                {
                    set += entry.Key + "=" + entry.Value + ",";
                }
            }

            foreach (var entry in originalRow.Fields)
            {
                if (entry.Value is string)
                {
                    where += entry.Key + "=" + "\"" + entry.Value + "\"" + " AND ";
                }
                else
                {
                    where += entry.Key + "=" + entry.Value + " AND ";
                }
            }
            set = set.Remove(set.LastIndexOf(","));
            where = where.Remove(where.LastIndexOf(" AND "));

            command.AppendLine("UPDATE " + target.Name);
            command.AppendLine("SET " + set);
            command.AppendLine("WHERE " + where);

            return command.ToString();
        }

    }
}
