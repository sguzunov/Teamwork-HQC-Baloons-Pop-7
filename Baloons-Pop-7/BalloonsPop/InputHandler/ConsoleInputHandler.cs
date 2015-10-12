namespace Balloons.InputHandler
{
    using System;

    using Balloons.Common;
    using Balloons.Helpers;
    using Balloons.Common.ConsoleContext;

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

        public ConsoleInputHandler(IConsoleWriter consoleWriter, IConsoleReader consoleReader)
        {
            this.consoleWriter = consoleWriter;
            this.consoleReader = consoleReader;
        }

        public ConsoleInputHandler()
            : this(new ConsoleWriter(), new ConsoleReader())
        {
        }

        public GameMode GetGameMode()
        {
            while (true)
            {
                Console.Write(GameModeInviteMessage);
                string input = consoleReader.ReadLine();
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

        public GameDifficulty GetGameDifficulty()
        {
            while (true)
            {
                Console.Write(GameDifficultyInviteMessage);
                string input = consoleReader.ReadLine();
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

        public AnotherRound GetPlayAgainResponse()
        {
            while (true)
            {
                Console.Write(PlayerResponseInviteMessage);
                string input = consoleReader.ReadLine();
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

        public string ReadInputCommand()
        {
            this.consoleWriter.Write(CommandInputInviteMessage);
            string userInput = consoleReader.ReadLine().Trim().ToLower();

            return userInput;
        }

        public string ReadPlayerInfo()
        {
            this.consoleWriter.Write(PlayerInfoInviteMessage);
            string playerName = consoleReader.ReadLine();

            return playerName;
        }
    }
}
