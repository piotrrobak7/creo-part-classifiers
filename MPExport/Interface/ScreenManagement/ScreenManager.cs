namespace MPExport.Interface
{
    sealed class ScreenManager
    {
        #region Singleton

        public static ScreenManager Instance { get; } = new ScreenManager();

        static ScreenManager() { }
        private ScreenManager() => _screenFactory = new ScreenFactory();

        #endregion

        private readonly ScreenFactory _screenFactory;
        
        public void ChangeScreen(ScreenType screenType, params string[] strings)
        {
            var screen = _screenFactory.Build(screenType, strings);
            ProgramState.Instance.Screen = screen;
            screen.Display();
        }
    }
}
