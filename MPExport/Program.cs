using System;
using MPExport.Interface;

namespace MPExport
{
    static class Program
    {
        public static void Main()
        {
            try
            {
                InputProcessor.Run("m");
                WaitForInput();
            }
            catch (Exception ex)
            {
                ScreenManager.Instance.ChangeScreen(ScreenType.FatalError, ex.Message, ex.StackTrace);
                Console.ReadLine();
            }
        }

        private static void WaitForInput()
        {
            while (true)
            {
                var input = Console.ReadLine();
                InputProcessor.Run(input);
            }
        }
    }
}
