using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM
{
    public interface IExitSignal
    {
        event EventHandler Exit;
    }

    public class WindowExitSignal
    {

        #region Trap application termination
        [System.Runtime.InteropServices.DllImport("Kernel32")]
        public static extern bool SetConsoleCtrlHandler(EventHandler handler, bool add);
        public delegate bool EventHandler(CtrlType sig);
        public delegate void ExitEventHandler();
        public event ExitEventHandler Exit;
        private EventHandler _handler;
        public enum CtrlType
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }

        public WindowExitSignal()
        {
            _handler += Handler;
            SetConsoleCtrlHandler(_handler, true);
        }

        private bool Handler(CtrlType sig)
        {
            Exit?.Invoke();
            return true;
        }
        #endregion
    }
}
