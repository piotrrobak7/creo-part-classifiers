using System;

namespace MPExport
{
    class InvalidPathEventArgs : EventArgs
    {
        public string ErrorMsg { get; }
        public InvalidPathEventArgs(string errorMsg) => ErrorMsg = errorMsg;
    }
}
