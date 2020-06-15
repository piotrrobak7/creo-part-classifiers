using System;
using MPExport.Interface;

namespace MPExport
{
    static class Program
    {
        public static void Main()
        {
            InputProcessor.Run("m");
            while (true)
            {
                var input = Console.ReadLine();
                InputProcessor.Run(input);
            }
        }
    }
}
