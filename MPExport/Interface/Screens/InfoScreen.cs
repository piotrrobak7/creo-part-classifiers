using System;

namespace MPExport.Interface
{
    static partial class ScreenFactory
    {
        private class InfoScreen : Screen
        {
            public override ScreenType Type => ScreenType.Info;

            public override string Title => Constants.ConsoleTitles.INFO;
            public override string Body => GetScreenBody();

            public override ConsoleColor ForegroundColor => ConsoleColor.Green;
            public override ConsoleColor BackgroundColor => ConsoleColor.Black;

            public override double WidthRatio => 0.3;
            public override double HeightRatio => 0.3;

            private string GetScreenBody()
            {
                return "Info screen";
            }
        }
    }
}
