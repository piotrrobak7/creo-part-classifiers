using System;

namespace MPExport.Interface
{
    static partial class ScreenFactory
    {
        private class MainScreen : Screen
        {
            #region Screen props

            public override ScreenType Type => ScreenType.Main;
            public override ProgramMode Mode => ProgramMode.LoadingPaths;

            public override string Title => Constants.ConsoleTitles.DEFAULT;
            public override string Body => GetScreenBody();

            public override ConsoleColor ForegroundColor => ConsoleColor.Yellow;
            public override ConsoleColor BackgroundColor => ConsoleColor.Blue;

            public override double WidthRatio => 0.3;
            public override double HeightRatio => 0.3;

            #endregion

            private string GetScreenBody()
            {
                return $@"
                
                *************************************************
                ********** CREO MASS PROPERTIES EXPORT **********
                *************************************************
                
                {GetMainScreenVariableText()}
                {GetAvailableCommands()}";
            }

            private string GetMainScreenVariableText()
            {
                if (ProgramState.Instance.InputFilePath == null)
                {
                    return @"
                    Enter path to the input file
                    [e]or ...
                    ".TrimStart();
                }

                if (ProgramState.Instance.OutputDirPath == null)
                {
                    return @"
                    Enter path to the output directory
                    [e]or ...
                    ".TrimStart();
                }

                return $@"
                Input file path: {ProgramState.Instance.InputFilePath}
                Output directory path: {ProgramState.Instance.OutputDirPath}
                ".TrimStart();
            }

            private string GetAvailableCommands()
            {
                if (ProgramState.Instance.OutputDirPath != null)
                {
                    return @"
                    Commands:
                    [t]s to start
                    [t]r to reset
                    [t]i to show info
                    [t]q to quit
                    ".TrimStart();
                }

                return @"
                    Commands:
                    [t]i to show info
                    [t]q to quit
                    ".TrimStart();
            }
        }
    }
}
