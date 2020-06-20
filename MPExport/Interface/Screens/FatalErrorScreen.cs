using System;

namespace MPExport.Interface
{
    partial class ScreenFactory
    {
        private class FatalErrorScreen : Screen
        {
            #region Screen props

            public override ScreenType Type => ScreenType.FatalError;
            public override ProgramMode Mode => ProgramMode.ReturnToMain;

            public override string Title => Constants.ConsoleTitles.ERROR;
            public override string Body => GetScreenBody();

            public override ConsoleColor ForegroundColor => ConsoleColor.DarkRed;
            public override ConsoleColor BackgroundColor => ConsoleColor.Black;

            public override double WidthRatio => 0.9;
            public override double HeightRatio => 0.5;

            #endregion

            public string Message { get; }
            public string StackTrace { get; }

            public FatalErrorScreen(string message, string stackTrace)
            {
                Message = message;
                StackTrace = stackTrace;
            }

            private string GetScreenBody()
            {
                return $@"
                
                *************************************************
                ********************* ERROR *********************
                *************************************************
                
                Error message:
                {Message}
                
                Stack trace:
                {StackTrace}
                
                Enter any key to exit
                ";
            }
        }
    }
}
