using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores.Connection
{
    public interface IConnection
    {
        bool Connected { get; }
        void Connect(string url );
        void Disconnect();
    }
}
