using System;
using System.Text.RegularExpressions;

namespace MPExport.Interface
{
    sealed class InputProcessor
    {
        #region Singleton

        public static InputProcessor Instance { get; } = new InputProcessor();

        static InputProcessor() { }
        private InputProcessor() { }

        #endregion

        #region Events

        public event EventHandler<ScreenRequestedEventArgs> ScreenChangeRequested;
        public event EventHandler<InvalidInputEventArgs> InvalidInputEntered;
        public event EventHandler<ValidPathEventArgs> InputFilePathEntered;
        public event EventHandler<ValidPathEventArgs> OutputDirPathEntered;

        private void OnScreenChangeRequested(string request) =>
            ScreenChangeRequested?.Invoke(null, new ScreenRequestedEventArgs(request));

        private void OnInvalidInputEntered(string errorMsg) =>
            InvalidInputEntered?.Invoke(null, new InvalidInputEventArgs(errorMsg));

        private void OnInputFilePathEntered(string path) =>
            InputFilePathEntered?.Invoke(null, new ValidPathEventArgs(path));

        private void OnOutputDirPathEntered(string path) =>
            OutputDirPathEntered?.Invoke(null, new ValidPathEventArgs(path));

        #endregion

        public void Run(string input)
        {
            if (ProgramState.Instance.ActiveScreenType == ScreenType.Error)
            {
                OnScreenChangeRequested("m");
                return;
            }

            input = input.Trim();
            switch (input)
            {
                case var i when new Regex(@"^[qQ]$").IsMatch(i): CloseApp(); break;
                case var i when new Regex(@"^[sS]$").IsMatch(i): StartProcessing(); break;
                case var i when new Regex(@"^[a-zA-Z]$").IsMatch(i): OnScreenChangeRequested(i); break;
                default: ValidatePath(input); break;
            }
        }
        
        private void CloseApp() => Environment.Exit(0);

        private void StartProcessing() => throw new NotImplementedException();

        private void ValidatePath(string path) => throw new NotImplementedException();
    }
}
