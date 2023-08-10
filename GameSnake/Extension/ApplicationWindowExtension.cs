using System.Runtime.InteropServices;

namespace GameSnake.Extension
{
    public static class ApplicationWindowExtension
    {
        public static void WindowSetting(this int heightForScore, int width, int height)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Console.SetWindowSize(width + 2, height + 2 + heightForScore);
                Console.SetBufferSize(width + 2, height + 2 + heightForScore);
            }

            Console.CursorVisible = false;
            Console.Title = "SNAKE";
        }
    }
}
