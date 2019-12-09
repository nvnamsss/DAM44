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
        }

        private ConnectionState _state;
        public event OnConnectHandler OnConnect;
        public event OnConnectHandler OnDisconnect;
        public event StateChangeHandler StateChanged;

        public abstract void Connect(string url);
        public abstract void Disconnect();

        protected virtual void SetState(ConnectionState state)
        {
            if (state != _state)
            {
                var e = new Event.Connection.StateChangedEventArgs(state, _state);
                _state = state;
                StateChanged?.Invoke(this, e);
            }
        }
    }
}
