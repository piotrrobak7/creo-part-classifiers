using MPExport.Interface;

namespace MPExport
{
    sealed class ProgramState
    {
        #region Singleton

        public static ProgramState Instance { get; } = new ProgramState();

        static ProgramState() { }
        private ProgramState() { }

        #endregion

        public Screen Screen { get; private set; }
        public ProgramMode Mode => Screen?.Mode ?? ProgramMode.LoadingPaths;

        public string InputFilePath { get; private set; }
        public string OutputDirPath { get; private set; }

        public void OnScreenChanged(object source, ScreenChangedEventArgs e) => Screen = e.Screen;
        public void OnInputFilePathEntered(object source, ValidPathEventArgs e) => InputFilePath = e.Path;
        public void OnOutputDirPathEntered(object source, ValidPathEventArgs e) => OutputDirPath = e.Path;
    }
}
