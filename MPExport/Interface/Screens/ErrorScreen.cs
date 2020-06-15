using System;

namespace MPExport.Interface
{
    partial class ScreenFactory
    {
        private class ErrorScreen : Screen
        {
            #region Screen props

            public override ScreenType Type => ScreenType.Error;
            public override ProgramMode Mode => ProgramMode.ReturnToMain;

            public override string Title => Constants.ConsoleTitles.ERROR;
            public override string Body => GetScreenBody();

            public override ConsoleColor ForegroundColor => ConsoleColor.DarkRed;
            public override ConsoleColor BackgroundColor => ConsoleColor.Black;

            public override double WidthRatio => 0.3;
            public override double HeightRatio => 0.3;

            #endregion

            public string Message { get; }
            public ErrorScreen(string message) => Message = message;

            private string GetScreenBody()
            {
                return $@"
                
                *************************************************
                ********************* ERROR *********************
                *************************************************
                
                Error message:
                {Message}
                
                Enter any key to go back
                ";
            }
        }
    }
}
