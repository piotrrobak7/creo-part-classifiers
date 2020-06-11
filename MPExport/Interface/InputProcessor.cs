using System;
using System.IO;
using System.Security;
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
        public event EventHandler<InvalidPathEventArgs> InvalidPathEntered;
        public event EventHandler<ValidPathEventArgs> InputFilePathEntered;
        public event EventHandler<ValidPathEventArgs> OutputDirPathEntered;

        private void OnScreenChangeRequested(string request) =>
            ScreenChangeRequested?.Invoke(null, new ScreenRequestedEventArgs(request));

        private void OnInvalidPathEntered(string errorMsg) =>
            InvalidPathEntered?.Invoke(null, new InvalidPathEventArgs(errorMsg));

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
                case string i when new Regex("^[sS]$").IsMatch(i): StartProcessing(); break;
                case string i when new Regex("^[rR]$").IsMatch(i): ResetPaths(); break;
                case string i when new Regex("^[qQ]$").IsMatch(i): Environment.Exit(0); break;
                case string i when new Regex("^[a-zA-Z]$").IsMatch(i): OnScreenChangeRequested(i); break;
                default: ValidatePath(input); break;
            }

            ProgramState.Instance.Screen.Display();
        }

        private void StartProcessing()
        {
            if (ProgramState.Instance.InputFilePath == null) return;
            if (ProgramState.Instance.OutputDirPath == null) return;

            throw new NotImplementedException();
        }

        private void ResetPaths()
        {
            OnInputFilePathEntered(null);
            OnOutputDirPathEntered(null);
        }

        private void ValidatePath(string path)
        {
            string errorMsg = null;

            if (path.Length > 0 && path[0] == '"' && path[path.Length - 1] == '"')
            {
                path = path.Remove(0, 1);
                path = path.Remove(path.Length - 1);
            }

            try { Path.GetFullPath(path); }
            catch (ArgumentException) { errorMsg = Constants.PathErrors.INVALID_CHARS_OR_EMPTY; }
            catch (SecurityException) { errorMsg = Constants.PathErrors.NO_ACCESS; }
            catch (NotSupportedException) { errorMsg = Constants.PathErrors.INVALID_CHARS_OR_EMPTY; }
            catch (PathTooLongException) { errorMsg = Constants.PathErrors.PATH_TO_LONG; }

            if (errorMsg == null && !Path.IsPathRooted(path)) errorMsg = Constants.PathErrors.PATH_NOT_ROOTED;
            if (errorMsg != null)
            {
                OnInvalidPathEntered(errorMsg);
                return;
            }

            if (ProgramState.Instance.InputFilePath == null) ValidateInputFilePath(path);
            else ValidateOutputDirPath(path);
        }

        private void ValidateInputFilePath(string path)
        {
            switch (Path.GetExtension(path))
            {
                case "": OnInvalidPathEntered(Constants.PathErrors.INPUT_FILE_FIRST); break;
                case Constants.AllowedExtensions.TXT: OnInputFilePathEntered(path); break;
                default: OnInvalidPathEntered(Constants.PathErrors.INVALID_FILE_TYPE); break;
            }
        }

        private void ValidateOutputDirPath(string path)
        {
            switch (Path.GetExtension(path))
            {
                case "": OnOutputDirPathEntered(path); break;
                default: OnInvalidPathEntered(Constants.PathErrors.NOT_DIRECTORY); break;
            }
        }

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
