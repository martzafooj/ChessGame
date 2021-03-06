using System;

namespace ChessGame
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Game1 game = Game1.Instance)
            {
                game.Run();
            }
        }
    }
#endif
}

