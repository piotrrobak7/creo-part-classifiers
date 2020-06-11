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
            input = input.Trim();

            switch (ProgramState.Instance.Mode)
            {
                case ProgramMode.LoadingPaths: HandleLoadingPathsInput(input);  break;
                case ProgramMode.ReturnToMain: HandleReturnToMainInput(); break;
                case ProgramMode.Processing: HandleProcessingInput(input); break;
                case ProgramMode.Ending: HandleEndingInput(input); break;
            }
        }

        #region Loading paths

        private void HandleLoadingPathsInput(string input)
        {
            switch (input)
            {
                case var i when new Regex(@"^[qQ]$").IsMatch(i): Environment.Exit(0); break;
                case var i when new Regex(@"^[sS]$").IsMatch(i): StartProcessing(); break;
                case var i when new Regex(@"^[a-zA-Z]$").IsMatch(i): OnScreenChangeRequested(i); break;
                default: ValidatePath(input); break;
            }

            ProgramState.Instance.Screen.Display();
        }

        private void StartProcessing() => throw new NotImplementedException();

        private void ValidatePath(string path) => throw new NotImplementedException();

        #endregion

        #region Return to main

        private void HandleReturnToMainInput() => OnScreenChangeRequested("m");

        #endregion

        #region Processing

        private void HandleProcessingInput(string input) => throw new NotImplementedException();

        #endregion

        #region Ending

        private void HandleEndingInput(string input) => throw new NotImplementedException();

        #endregion
    }
}
