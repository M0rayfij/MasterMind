// Game.cs
// Contains the main game logic and loop.

namespace Mastermind
{
    /// <summary>
    /// Represents the core engine of the Mastermind game.
    /// This class manages the game state, including the secret code,
    /// the number of attempts remaining, and the main game loop.
    /// </summary>
    public class Game
    {
        private readonly Code _secretCode;
        private int _attemptsRemaining;
        private int _currentRound = 0;

        /// <summary>
        /// Initializes a new instance of the Game class.
        /// </summary>
        /// <param name="settings">The settings for the game, including the secret code and number of attempts.</param>
        public Game(GameSettings settings)
        {
            _attemptsRemaining = settings.Attempts;

            // If a secret code is provided in settings, use it. Otherwise, generate a random one.
            if (!string.IsNullOrEmpty(settings.SecretCode))
            {
                // This will throw an ArgumentException if the provided code is invalid,
                // which is caught in Program.Main.
                _secretCode = new Code(settings.SecretCode);
            }
            else
            {
                _secretCode = Code.GenerateRandom();
            }
        }

        /// <summary>
        /// Starts and manages the main game loop.
        /// </summary>
        public void Run()
        {
            Console.WriteLine("Will you find the secret code?");
            Console.WriteLine("Please enter a valid guess");

            while (_attemptsRemaining > 0)
            {
                Console.WriteLine("---");
                Console.WriteLine($"Round {_currentRound}");
                Console.Write(">");

                string? input = Console.ReadLine();

                // Handle EOF (Ctrl+D on Unix, Ctrl+Z on Windows)
                if (input == null)
                {
                    Console.WriteLine("\nExecution stopped.");
                    break;
                }

                Code guessCode;
                try
                {
                    // Validate the player's input by attempting to create a Code object.
                    guessCode = new Code(input);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Wrong input!");
                    continue; // Skip the rest of the loop and ask for input again.
                }

                // Compare the guess against the secret code.
                GuessResult result = _secretCode.CheckGuess(guessCode);

                if (result.IsCorrect)
                {
                    Console.WriteLine("Congratz! You did it!");
                    return; // End the game on win.
                }

                // Provide feedback to the player.
                Console.WriteLine($"Well placed pieces: {result.WellPlacedPieces}");
                Console.WriteLine($"Misplaced pieces: {result.MisplacedPieces}");

                _attemptsRemaining--;
                _currentRound++;
            }

            if (_attemptsRemaining == 0)
            {
                Console.WriteLine("---");
                Console.WriteLine("You ran out of attempts. Game over.");
                Console.WriteLine($"The secret code was: {_secretCode.Value}");
            }
        }
    }
}
