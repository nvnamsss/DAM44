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
        public event OnErrorHandler OnError;
        public event OnConnectHandler OnDisconnect;
        public event StateChangeHandler StateChanged;

        public abstract void Connect(string url);
        public abstract void Connect();
        public abstract void Disconnect();
        protected StringBuilder connectionString;
        protected System.Data.Common.DbConnection _connection;
        protected System.Data.Common.DbCommand _command;
        protected System.Data.Common.DbTransaction _transaction;
        protected virtual void OnConnectInvoke()
        {
            OnConnect?.Invoke(this);
        }

        protected virtual void OnErrorInvoke(Exception e)
        {
            OnError?.Invoke(this, e);
        }

        protected virtual void OnDisconnectInvoke()
        {
            OnDisconnect?.Invoke(this);
        }

        public virtual void SendRequest(string query)
        {

        }

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
