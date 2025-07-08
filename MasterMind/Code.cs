// Code.cs
// Represents and validates a 4-digit code.

namespace Mastermind
{
    /// <summary>
    /// Represents a 4-digit Mastermind code.
    /// This class encapsulates the value and validation logic for a code,
    /// ensuring it always meets the game's rules (4 distinct digits from '0'-'8').
    /// It also provides the core logic for comparing a guess to a secret code.
    /// </summary>
    public class Code
    {
        public const int CODE_LENGTH = 4;
        public const string VALID_PIECES = "012345678";
        public string Value { get; }

        /// <summary>
        /// Initializes a new Code object from a string value.
        /// Performs validation to ensure the code is valid.
        /// </summary>
        /// <param name="codeValue">The 4-digit string for the code.</param>
        /// <exception cref="ArgumentException">Thrown if the code is invalid.</exception>
        public Code(string codeValue)
        {
            Validate(codeValue);
            Value = codeValue;
        }

        /// <summary>
        /// Compares this code (the secret) with a guess code.
        /// </summary>
        /// <param name="guess">The player's guess.</param>
        /// <returns>A GuessResult object with the count of well-placed and misplaced pieces.</returns>
        public GuessResult CheckGuess(Code guess)
        {
            int wellPlaced = 0;
            int misplaced = 0;

            // Use LINQ for a concise way to count total correct pieces.
            // This finds all characters from the guess that are also present in the secret code.
            int totalCorrectPieces = guess.Value.Count(piece => this.Value.Contains(piece));

            // Calculate well-placed pieces by checking for same character at the same position.
            for (int i = 0; i < CODE_LENGTH; i++)
            {
                if (this.Value[i] == guess.Value[i])
                {
                    wellPlaced++;
                }
            }

            // Misplaced pieces are the total correct pieces minus the well-placed ones.
            misplaced = totalCorrectPieces - wellPlaced;

            return new GuessResult(wellPlaced, misplaced);
        }

        /// <summary>
        /// Generates a new random, valid Mastermind code.
        /// </summary>
        /// <returns>A new Code object with a random value.</returns>
        public static Code GenerateRandom()
        {
            var random = new Random();
            // Shuffle the valid pieces and take the first 4 to ensure uniqueness.
            var shuffledPieces = VALID_PIECES.ToCharArray().OrderBy(x => random.Next()).ToArray();
            var randomCodeString = new string(shuffledPieces.Take(CODE_LENGTH).ToArray());
            return new Code(randomCodeString);
        }

        /// <summary>
        /// Validates a given string to see if it's a valid code.
        /// </summary>
        private void Validate(string codeValue)
        {
            if (codeValue.Length != CODE_LENGTH)
                throw new ArgumentException($"Code must be {CODE_LENGTH} characters long.");

            if (codeValue.Distinct().Count() != CODE_LENGTH)
                throw new ArgumentException("Code must contain unique characters.");

            foreach (char c in codeValue)
            {
                if (!VALID_PIECES.Contains(c))
                    throw new ArgumentException($"Code contains invalid character '{c}'. Only digits from '0' to '8' are allowed.");
            }
        }
    }
}
