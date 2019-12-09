using DAM.Cores.Connection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores.Event.Connection
{
    public class StateChangedEventArgs : EventArgs
    {
        public ConnectionState NewState { get; }
        public ConnectionState OldState { get; }
        public StateChangedEventArgs(ConnectionState newState, ConnectionState oldState)
        {
            NewState = newState;
            OldState = oldState;
        }
    }
}
