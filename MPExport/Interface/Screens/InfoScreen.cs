using System;

namespace MPExport.Interface
{
    static partial class ScreenFactory
    {
        private class InfoScreen : Screen
        {
            #region Screen props

            public override ScreenType Type => ScreenType.Info;
            public override ProgramMode Mode => ProgramMode.ReturnToMain;

            public override string Title => Constants.ConsoleTitles.INFO;
            public override string Body => GetScreenBody();

            public override ConsoleColor ForegroundColor => ConsoleColor.Yellow;
            public override ConsoleColor BackgroundColor => ConsoleColor.Blue;

            public override double WidthRatio => 0.3;
            public override double HeightRatio => 0.4;

            #endregion

            private string GetScreenBody()
            {
                return @"
                
                *************************************************
                ********************* INFO **********************
                *************************************************
                
                This app uses Creo Parametric in the background
                to open parts and export their mass properties.
                
                To run it you need to pass paths to the input
                file and output directory.
                
                Input file:
                Plain txt file where adresses of parts are
                stored. One line, one file.
                
                Output directory:
                Location where resulting files will be created.
                
                Enter any key to go back
                ";
            }
        }
    }
}
