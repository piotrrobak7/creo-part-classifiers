using System;

namespace MPExport.Interface
{
    static partial class ScreenFactory
    {
        private class ErrorScreen : Screen
        {
            public override ScreenType Type => ScreenType.Error;

            public override string Title => Constants.ConsoleTitles.ERROR;
            public override string Body => GetScreenBody();

            public override ConsoleColor ForegroundColor => ConsoleColor.Green;
            public override ConsoleColor BackgroundColor => ConsoleColor.Black;

            public override double WidthRatio => 0.3;
            public override double HeightRatio => 0.3;

            private string GetScreenBody()
            {
                return "Error screen";
            }
        }
    }
}
