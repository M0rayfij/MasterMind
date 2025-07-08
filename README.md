# MasterMind
Steer Elite Internship Program Skills Assessment – Gameplay Programming Track
# C# Mastermind

## Project Description

This project is a console-based implementation of the classic code-breaking game, Mastermind. It is written in C# and designed with a strong emphasis on Object-Oriented Programming (OOP) principles, including encapsulation, separation of concerns, and clear class responsibilities.

The game challenges a player to guess a secret 4-digit code composed of unique numbers from '0' to '8'. After each guess, the player receives feedback on how many pieces were well-placed or misplaced, helping them deduce the secret code within a limited number of attempts.

## How to Build and Run

### Prerequisites

* [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) or a later version.

### Instructions

1.  **Clone the Repository**
    ```bash
    # Replace with the actual repository URL
    git clone [https://github.com/your-username/my_mastermind.git](https://github.com/your-username/my_mastermind.git)
    cd my_mastermind
    ```

2.  **Build the Project**
    Run the following command in the root directory of the project. This will compile the code and create an executable.
    ```bash
    dotnet build
    ```

3.  **Run the Game**
    You can run the game using the `dotnet run` command. The `--` separator is used to pass arguments directly to the application.

    * **To play with a random code and 10 attempts:**
        ```bash
        dotnet run
        ```

    * **To specify a secret code:**
        ```bash
        dotnet run -- -c "1234"
        ```

    * **To specify the number of attempts:**
        ```bash
        dotnet run -- -t 8
        ```

    * **To specify both a code and the number of attempts:**
        ```bash
        dotnet run -- -c "5678" -t 12
        ```

## Gameplay

* **Objective**: Guess the secret 4-digit code.
* **Code Rules**: The code consists of 4 unique digits, where each digit is between '0' and '8'.
* **Attempts**: You have 10 attempts by default, but this can be changed with the `-t` option.
* **Feedback**:
    * `Well placed pieces`: The number of correct digits in the correct position.
    * `Misplaced pieces`: The number of correct digits that are in the wrong position.
* **Winning**: You win if you guess the code correctly.
* **Losing**: You lose if you run out of attempts.

## Project Structure

The project is organized into several classes to promote clean and maintainable code:

* `Program.cs`: The application's main entry point. Handles top-level control flow.
* `Game.cs`: The main game engine. Manages the game loop, state, and player interaction.
* `GameSettings.cs`: Parses and stores command-line arguments (`-c`, `-t`).
* `Code.cs`: Represents a game code (either the secret or a guess). Handles validation, generation, and comparison logic.
* `GuessResult.cs`: A simple data class to hold the feedback for a given guess.
