using System;

namespace MPExport.Interface
{
    static partial class ScreenFactory
    {
        private class MainScreen : Screen
        {
            public override ScreenType Type => ScreenType.Main;

            public override string Title => Constants.ConsoleTitles.DEFAULT;
            public override string Body => GetScreenBody();

            public override ConsoleColor ForegroundColor => ConsoleColor.Green;
            public override ConsoleColor BackgroundColor => ConsoleColor.Black;

            public override double WidthRatio => 0.3;
            public override double HeightRatio => 0.3;
            
            private string GetScreenBody()
            {
                return "Main screen";
            }
        }
    }
}
