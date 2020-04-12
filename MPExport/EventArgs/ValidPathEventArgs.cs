using System;

namespace MPExport
{
    class ValidPathEventArgs : EventArgs
    {
        public string Path { get; }
        public ValidPathEventArgs(string path) => Path = path;
    }
}
