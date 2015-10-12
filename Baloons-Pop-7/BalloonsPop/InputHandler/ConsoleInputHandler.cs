namespace Balloons.InputHandler
{
    using System;

    using Balloons.Common;
    using Balloons.Common.ConsoleContext;
    using Balloons.Helpers;

    /// <summary>
    /// Console implementation of input handler.
    /// </summary>
    public class ConsoleInputHandler : IInputHandler
    {
        // Handler error messages
        private const string GameModeErrorMessage = "Invalid game mode!";
        private const string GameDifficultyErrorMessage = "Invalid game difficulty!";
        private const string PlayAgainAnswerErrorMessage = "Invalid answer!";

        private const string GameModeInviteMessage = "Select a game mode: please type 'default' or 'fly': ";
        private const string GameDifficultyInviteMessage = "Select a game difficulty: please type 'easy' or 'hard': ";
        private const string PlayerResponseInviteMessage = "Do you want to play again? Please type 'yes' or 'no': ";
        private const string CommandInputInviteMessage = @"Enter a command ('pop {{row}} {{col}}', 'top', 'save', 'restore', 'help', 'exit'): ";
        private const string PlayerInfoInviteMessage = "Please enter your name: ";

        private IConsoleWriter consoleWriter;
        private IConsoleReader consoleReader;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleInputHandler"/> class.
        /// </summary>
        /// <param name="consoleWriter">Console context for writing.</param>
        /// <param name="consoleReader">Console context for reading.</param>
        public ConsoleInputHandler(IConsoleWriter consoleWriter, IConsoleReader consoleReader)
        {
            this.consoleWriter = consoleWriter;
            this.consoleReader = consoleReader;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleInputHandler"/> class.
        /// </summary>
        public ConsoleInputHandler()
            : this(new ConsoleWriter(), new ConsoleReader())
        {
        }

        /// <summary>
        /// Method which provides a way to get the game mode from console.
        /// </summary>
        /// <returns>Converted mode to enumeration.</returns>
        public GameMode GetGameMode()
        {
            while (true)
            {
                Console.Write(GameModeInviteMessage);
                string input = this.consoleReader.ReadLine();
                string gameModeAsString = input.Trim().ToLower();
                bool isValidGameMode = Validator.CheckIfValidGameMode(gameModeAsString);

                if (isValidGameMode)
                {
                    var gameMode = EnumUtils.GetGameModeFromString(gameModeAsString);
                    return gameMode;
                }
                else
                {
                    ConsoleHelper.DisplayInputErrorMessage(GameModeErrorMessage, this.consoleWriter);
                }
            }
        }

        /// <summary>
        /// Method which provides a way to get the game difficulty from console.
        /// </summary>
        /// <returns>Converted difficulty to enumeration.</returns>
        public GameDifficulty GetGameDifficulty()
        {
            while (true)
            {
                Console.Write(GameDifficultyInviteMessage);
                string input = this.consoleReader.ReadLine();
                string gameDifficultyAsString = input.Trim().ToLower();
                bool isValidGameDifficulty = Validator.CheckIfValidGameDifficulty(gameDifficultyAsString);

                if (isValidGameDifficulty)
                {
                    ConsoleHelper.ClearConsole();

                    var gameDifficulty = EnumUtils.GetGameDifficultyFromString(gameDifficultyAsString);
                    return gameDifficulty;
                }
                else
                {
                    ConsoleHelper.DisplayInputErrorMessage(GameDifficultyErrorMessage, this.consoleWriter);
                }
            }
        }

        /// <summary>
        /// Method which provides a way to get the player answer from console.
        /// </summary>
        /// <returns>Converted answer to enumeration.</returns>
        public AnotherRound GetPlayAgainResponse()
        {
            while (true)
            {
                Console.Write(PlayerResponseInviteMessage);
                string input = this.consoleReader.ReadLine();
                string answerAsString = input.Trim().ToLower();
                bool isValidAnswer = Validator.CheckIfValidAnswer(answerAsString);

                if (isValidAnswer)
                {
                    var answer = EnumUtils.GetPlayAgainAnswerFromString(answerAsString);
                    return answer;
                }
                else
                {
                    ConsoleHelper.DisplayInputErrorMessage(PlayAgainAnswerErrorMessage, this.consoleWriter);
                }
            }
        }

        /// <summary>
        /// Method which provides a way to get command as string which needs to be executed.
        /// </summary>
        /// <returns>Command input.</returns>
        public string ReadInputCommand()
        {
            this.consoleWriter.Write(CommandInputInviteMessage);
            string userInput = this.consoleReader.ReadLine().Trim().ToLower();

            return userInput;
        }

        /// <summary>
        /// Method which provides a way to get players info for statistics.
        /// </summary>
        /// <returns>Command input.</returns>
        public string ReadPlayerInfo()
        {
            this.consoleWriter.Write(PlayerInfoInviteMessage);
            string playerName = this.consoleReader.ReadLine();

            return playerName;
        }
    }
}
