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

        public Screen Screen { get; set; }
        public ProgramMode Mode => Screen?.Mode ?? ProgramMode.ReturnToMain;
        public bool ReadyForProcessing => InputFilePath != null && OutputDirPath != null;

        public string InputFilePath { get; set; }
        public string OutputDirPath { get; set; }
    }
}
