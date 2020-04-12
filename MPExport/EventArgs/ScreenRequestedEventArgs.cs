using System;

namespace MPExport
{
    class ScreenRequestedEventArgs : EventArgs
    {
        public string Request { get; }
        public ScreenRequestedEventArgs(string request) => Request = request;
    }
}
