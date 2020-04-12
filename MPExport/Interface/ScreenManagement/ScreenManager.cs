using System;
using System.Text.RegularExpressions;

namespace MPExport.Interface
{
    sealed class ScreenManager
    {
        #region Singleton

        public static ScreenManager Instance { get; } = new ScreenManager();

        static ScreenManager() { }
        private ScreenManager() { }

        #endregion

        #region Event handlers

        public void OnScreenChangeRequested(object source, ScreenRequestedEventArgs e)
        {
            switch (e.Request)
            {
                case var r when new Regex(@"[iI]").IsMatch(r): ChangeScreen(ScreenType.Info); break;
                case var r when new Regex(@"[mM]").IsMatch(r): ChangeScreen(ScreenType.Main); break;
                default: break;
            }
        }

        public void OnInvalidInputEntered(object source, InvalidInputEventArgs e) =>
            ChangeScreen(ScreenType.Error, e.ErrorMsg);

        #endregion

        #region Event sender

        public event EventHandler<ScreenChangedEventArgs> ScreenChanged;

        private void OnScreenChanged(Screen screen) =>
            ScreenChanged?.Invoke(null, new ScreenChangedEventArgs(screen));

        #endregion

        private void ChangeScreen(ScreenType screenType, params string[] strings)
        {
            var screen = ScreenFactory.Build(screenType, strings);
            screen.Display();
            OnScreenChanged(screen);
        }
    }
}
