using System;
using MPExport.Interface;

namespace MPExport
{
    class ScreenChangedEventArgs : EventArgs
    {
        public Screen Screen { get; }
        public ScreenChangedEventArgs(Screen screen) => Screen = screen;
    }
}
