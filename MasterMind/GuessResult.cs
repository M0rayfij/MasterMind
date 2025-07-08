// GuessResult.cs
// A simple data object to hold guess results.

namespace Mastermind
{
    /// <summary>
    /// A simple data-holding object (or struct) that represents the outcome of a guess.
    /// It encapsulates the number of well-placed and misplaced pieces.
    /// This makes method return types cleaner than using tuples or out parameters.
    /// </summary>
    public class GuessResult
    {
        public int WellPlacedPieces { get; }
        public int MisplacedPieces { get; }

        /// <summary>
        /// A convenience property to quickly check if the guess was entirely correct.
        /// </summary>
        public bool IsCorrect => WellPlacedPieces == Code.CODE_LENGTH;

        public GuessResult(int wellPlaced, int misplaced)
        {
            WellPlacedPieces = wellPlaced;
            MisplacedPieces = misplaced;
        }
    }
}
