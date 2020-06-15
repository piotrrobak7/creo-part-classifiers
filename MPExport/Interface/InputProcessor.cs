using System;
using System.IO;
using System.Security;
using System.Text.RegularExpressions;

namespace MPExport.Interface
{
    static class InputProcessor
    {
        public static void Run(string input)
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

        private static void HandleLoadingPathsInput(string input)
        {
            switch (input)
            {
                case string i when new Regex("^[sS]$").IsMatch(i): StartProcessing(); break;
                case string i when new Regex("^[rR]$").IsMatch(i): ResetPaths(); break;
                case string i when new Regex("^[iI]$").IsMatch(i): ScreenManager.Instance.ChangeScreen(ScreenType.Info); break;
                case string i when new Regex("^[qQ]$").IsMatch(i): Environment.Exit(0); break;
                default: ValidatePath(input); break;
            }

            ProgramState.Instance.Screen.Display();
        }

        private static void StartProcessing()
        {
            if (!ProgramState.Instance.ReadyForProcessing) return;

            throw new NotImplementedException();
        }

        private static void ResetPaths()
        {
            if (!ProgramState.Instance.ReadyForProcessing) return;

            ProgramState.Instance.InputFilePath = null;
            ProgramState.Instance.OutputDirPath = null;
        }

        private static void ValidatePath(string path)
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
                ScreenManager.Instance.ChangeScreen(ScreenType.Error, errorMsg);
                return;
            }

            if (ProgramState.Instance.InputFilePath == null) ValidateInputFilePath(path);
            else ValidateOutputDirPath(path);
        }

        private static void ValidateInputFilePath(string path)
        {
            switch (Path.GetExtension(path))
            {
                case "": ScreenManager.Instance.ChangeScreen(ScreenType.Error, Constants.PathErrors.INPUT_FILE_FIRST); break;
                case Constants.AllowedExtensions.TXT: ProgramState.Instance.InputFilePath = path; break;
                default: ScreenManager.Instance.ChangeScreen(ScreenType.Error, Constants.PathErrors.INVALID_FILE_TYPE); break;
            }
        }

        private static void ValidateOutputDirPath(string path)
        {
            switch (Path.GetExtension(path))
            {
                case "": ProgramState.Instance.OutputDirPath = path; break;
                default: ScreenManager.Instance.ChangeScreen(ScreenType.Error, Constants.PathErrors.NOT_DIRECTORY); break;
            }
        }

        #endregion

        #region Return to main

        private static void HandleReturnToMainInput() => ScreenManager.Instance.ChangeScreen(ScreenType.Main);

        #endregion

        #region Processing

        private static void HandleProcessingInput(string input) => throw new NotImplementedException();

        #endregion

        #region Ending

        private static void HandleEndingInput(string input) => throw new NotImplementedException();

        #endregion
    }
}
