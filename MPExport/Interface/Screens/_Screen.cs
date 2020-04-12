using System;

namespace MPExport.Interface
{
    abstract class Screen
    {
        public abstract ScreenType Type { get; }

        public abstract string Title { get; }
        public abstract string Body { get; }

        public abstract double WidthRatio { get; }
        public abstract double HeightRatio { get; }

        public abstract ConsoleColor ForegroundColor { get; }
        public abstract ConsoleColor BackgroundColor { get; }
        
        public void Display()
        {
            Console.ForegroundColor = ForegroundColor;
            Console.BackgroundColor = BackgroundColor;
            Console.Clear();

            Console.Title = Title;
            Console.Write(Body.TrimStart().Replace("  ", String.Empty));

            int maxWidth = Console.LargestWindowWidth;
            int maxHeight = Console.LargestWindowHeight;
            int consoleWidth = (int)(maxWidth * WidthRatio);
            int consoleHeight = (int)(maxHeight * HeightRatio);
            Console.SetWindowSize(consoleWidth, consoleHeight);
            Console.SetBufferSize(consoleWidth, consoleHeight);
        }
    }
}
