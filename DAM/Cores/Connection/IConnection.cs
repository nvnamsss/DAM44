using DAM.Cores.Event.Connection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores.Connection
{
    public delegate void OnConnectHandler(IConnection sender);
    public delegate void OnDisconnectHandler(IConnection sender);
    public delegate void StateChangeHandler(IConnection state, StateChangedEventArgs e);
    public interface IConnection
    {
        event OnConnectHandler OnConnect;
        event OnConnectHandler OnDisconnect;
        event StateChangeHandler StateChanged;
        ConnectionState ConnectionState { get; }
        void Connect(string url);
        void Disconnect();
    }
}
