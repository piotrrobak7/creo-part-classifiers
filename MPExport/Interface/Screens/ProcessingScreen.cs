﻿using System;

namespace MPExport.Interface
{
    static partial class ScreenFactory
    {
        private class ProcessingScreen : Screen
        {
            public override ScreenType Type => throw new NotImplementedException();
            public override string Title => throw new NotImplementedException();
            public override string Body => throw new NotImplementedException();
            public override double WidthRatio => throw new NotImplementedException();
            public override double HeightRatio => throw new NotImplementedException();
            public override ConsoleColor ForegroundColor => throw new NotImplementedException();
            public override ConsoleColor BackgroundColor => throw new NotImplementedException();
        }
    }
}