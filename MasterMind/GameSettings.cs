// GameSettings.cs
// Parses and holds command-line arguments.

namespace Mastermind
{
    /// <summary>
    /// A class responsible for parsing and storing the game's configuration,
    /// which is provided via command-line arguments. This separates the concern
    /// of argument parsing from the core game logic.
    /// </summary>
    public class GameSettings
    {
        public string? SecretCode { get; private set; }
        public int Attempts { get; private set; } = 10; // Default value

        // Private constructor to prevent direct instantiation.
        private GameSettings() { }

        /// <summary>
        /// Parses the command-line arguments to create a GameSettings object.
        /// This is a factory method pattern.
        /// </summary>
        /// <param name="args">The string array from Program.Main.</param>
        /// <returns>A configured GameSettings object.</returns>
        /// <exception cref="ArgumentException">Thrown if arguments are invalid.</exception>
        public static GameSettings Parse(string[] args)
        {
            var settings = new GameSettings();

            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-c":
                        if (i + 1 < args.Length)
                        {
                            settings.SecretCode = args[++i]; // Increment i to consume the value
                        }
                        else
                        {
                            throw new ArgumentException("Argument '-c' must be followed by a code.");
                        }
                        break;

                    case "-t":
                        if (i + 1 < args.Length)
                        {
                            if (int.TryParse(args[++i], out int attempts) && attempts > 0)
                            {
                                settings.Attempts = attempts;
                            }
                            else
                            {
                                throw new ArgumentException("Value for '-t' must be a positive integer.");
                            }
                        }
                        else
                        {
                            throw new ArgumentException("Argument '-t' must be followed by a number.");
                        }
                        break;
                }
            }

            return settings;
        }
    }
}
