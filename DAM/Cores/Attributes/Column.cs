using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores.Attributes
{
    public class ColumnAttribute : Attribute
    {
        public virtual string Name { get; set; }
        public ColumnAttribute() : this(string.Empty)
        {

        }

        public ColumnAttribute(string name)
        {
            Name = name;
        }
    }
}
