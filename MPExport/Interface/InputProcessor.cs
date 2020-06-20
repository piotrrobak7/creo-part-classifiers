using System;
using System.Text.RegularExpressions;
using MPExport.FileProcessing;

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
            if (ProgramState.Instance.ReadyForProcessing)
            {
                switch (input)
                {
                    case string i when new Regex("^[sS]$").IsMatch(i): StartProcessing(); break;
                    case string i when new Regex("^[rR]$").IsMatch(i): ResetPaths(); break;
                    case string i when new Regex("^[iI]$").IsMatch(i): ScreenManager.Instance.ChangeScreen(ScreenType.Info); break;
                    case string i when new Regex("^[qQ]$").IsMatch(i): Environment.Exit(0); break;
                }
            }
            else
            {
                switch (input)
                {
                    case string i when new Regex("^[iI]$").IsMatch(i): ScreenManager.Instance.ChangeScreen(ScreenType.Info); break;
                    case string i when new Regex("^[qQ]$").IsMatch(i): Environment.Exit(0); break;
                    default: ValidatePath(input); break;
                }
            }

            ProgramState.Instance.Screen.Display();
        }

        private static void StartProcessing()
        {
            throw new NotImplementedException();
        }

        private static void ResetPaths()
        {
            ProgramState.Instance.InputFilePath = null;
            ProgramState.Instance.OutputDirPath = null;
        }

        private static void ValidatePath(string path)
        {
            ValidationResult result = null;

            if (ProgramState.Instance.InputFilePath == null)
            {
                result = PathValidator.ValidateInputFilePath(path);
                ProgramState.Instance.InputFilePath = result.Valid ? path : null;
            }
            else
            {
                result = PathValidator.ValidateOutputDirPath(path);
                ProgramState.Instance.OutputDirPath = result.Valid ? path : null;
            }

            if (!result.Valid) ScreenManager.Instance.ChangeScreen(ScreenType.Error, result.Message);
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
