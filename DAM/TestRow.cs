using DAM.Cores.Attributes;
using DAM.Cores.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM
{
    public class TestRow : RowObject
    {
        [Column("Server_name")]
        public string name { get; set; }

        [Column("Host")]
        public string host { get; set; }
        [Column("Port")]
        public int port { get; set; }
    }
}
