// Program.cs
// Main entry point for the application.

namespace Mastermind
{
    /// <summary>
    /// The main class that serves as the entry point for the Mastermind game.
    /// Its primary responsibility is to parse command-line arguments,
    /// initialize the game settings, and run the game.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">Command-line arguments (-c for code, -t for attempts).</param>
        public static void Main(string[] args)
        {
            try
            {
                // 1. Parse command-line arguments to get game settings.
                var settings = GameSettings.Parse(args);

                // 2. Create a new game instance with the parsed settings.
                var game = new Game(settings);

                // 3. Run the game loop.
                game.Run();
            }
            catch (ArgumentException ex)
            {
                // Catch potential errors from argument parsing (e.g., invalid attempts value)
                // or code validation (e.g., user-provided code is invalid).
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
