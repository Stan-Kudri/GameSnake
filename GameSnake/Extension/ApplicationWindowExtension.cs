using System.Runtime.InteropServices;

namespace GameSnake.Extension
{
    public static class ApplicationWindowExtension
    {
        private const int CorrectionFactor = 2;

        public static void WindowSetting(this int heightForScore, int width, int height)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Console.SetWindowSize(width + CorrectionFactor, height + CorrectionFactor + heightForScore);
                Console.SetBufferSize(width + CorrectionFactor, height + CorrectionFactor + heightForScore);
            }

            Console.CursorVisible = false;
            Console.Title = "SNAKE";
        }
    }
}
