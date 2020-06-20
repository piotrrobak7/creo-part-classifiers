using System;

namespace MPExport.Interface
{
    partial class ScreenFactory
    {
        public ScreenFactory()
        {
            if (ScreenManager.Instance != null) ThrowForbiddenInitializationException();
            // This makes ScreenFactory a singleton
        }

        public Screen Build(ScreenType screenType, params string[] strings)
        {
            switch (screenType)
            {
                case ScreenType.Main: return new MainScreen();
                case ScreenType.Info: return new InfoScreen();
                case ScreenType.Error: return new ErrorScreen(strings[0]);
                case ScreenType.FatalError: return new FatalErrorScreen(strings[0], strings[1]);
                case ScreenType.Processing: return new ProcessingScreen();
                case ScreenType.End: return new EndScreen();
                default: ThrowInvalidScreenTypeException(); return null;
            }
        }

        private void ThrowInvalidScreenTypeException()
        {
            const string errorMsg = "Provided screen type is not implemented!";
            throw new ArgumentException(errorMsg);
        }

        private void ThrowForbiddenInitializationException()
        {
            const string errorMsg = "ScreenFactory object can exist only inside ScreenManager!";
            throw new ArgumentException(errorMsg);
        }
    }
}
