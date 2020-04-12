using System;
using MPExport.Interface;

namespace MPExport
{
    class Program
    {
        public static void Main(string[] args)
        {
            Initialize();
            while (true)
            {
                var input = Console.ReadLine();
                InputProcessor.Instance.Run(input);
            }
        }

        private static void Initialize()
        {
            InputProcessor.Instance.ScreenChangeRequested += ScreenManager.Instance.OnScreenChangeRequested;
            InputProcessor.Instance.InvalidInputEntered += ScreenManager.Instance.OnInvalidInputEntered;

            InputProcessor.Instance.InputFilePathEntered += ProgramState.Instance.OnInputFilePathEntered;
            InputProcessor.Instance.OutputDirPathEntered += ProgramState.Instance.OnOutputDirPathEntered;
            ScreenManager.Instance.ScreenChanged += ProgramState.Instance.OnScreenChanged;

            InputProcessor.Instance.Run("m");
        }
    }
}
