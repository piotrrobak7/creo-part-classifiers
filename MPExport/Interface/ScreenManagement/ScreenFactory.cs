using System;

namespace MPExport.Interface
{
    static partial class ScreenFactory
    {
        public static Screen Build(ScreenType screenType, params string[] strings)
        {
            switch (screenType)
            {
                case ScreenType.Main: return new MainScreen();
                case ScreenType.Info: return new InfoScreen();
                case ScreenType.Error: return new ErrorScreen();
                case ScreenType.Processing: return new ProcessingScreen();
                case ScreenType.End: return new EndScreen();
                default: ThrowInvalidScreenTypeException(); return null;
            }
        }

        private static void ThrowInvalidScreenTypeException()
        {
            string errorMsg = "Provided screen type is not implemented";
            throw new ArgumentException(errorMsg);
        }
    }
}
