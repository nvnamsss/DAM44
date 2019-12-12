using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores.Connection
{
    public abstract class DbConnection : IConnection
    {
        public ConnectionState ConnectionState
        {
            get
            {
                return _state;
            }
            protected set
            {
                if (value != _state)
                {
                    var e = new Event.Connection.StateChangedEventArgs(value, ConnectionState);
                    _state = value;
                    StateChanged?.Invoke(this, e);
                }
            }
        }
        private ConnectionState _state;
        public event OnConnectHandler OnConnect;
        public event OnConnectHandler OnDisconnect;
        public event StateChangeHandler StateChanged;

        public abstract void Connect(string url);
        public abstract void Disconnect();
        protected StringBuilder connectionString;
        //protected virtual void SetState(ConnectionState state)
        //{
        //    if (state != ConnectionState)
        //    {
        //        var e = new Event.Connection.StateChangedEventArgs(state, ConnectionState);
        //        ConnectionState = state;
        //        StateChanged?.Invoke(this, e);
        //    }
        //}
    }
}
