using System;

namespace MPExport
{
    class InvalidInputEventArgs : EventArgs
    {
        public string ErrorMsg { get; }
        public InvalidInputEventArgs(string errorMsg) => ErrorMsg = errorMsg;
    }
}
