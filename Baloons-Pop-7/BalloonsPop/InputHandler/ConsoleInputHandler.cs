namespace Balloons.InputHandler
{
    using System;

    using Balloons.Common;
    using Balloons.FieldFactory.Field;
    using Balloons.Helpers;

    public class ConsoleInputHandler : IInputHandler
    {
        // Handler error messages
        private const string GameModeErrorMessage = "Invalid game mode!";
        private const string GameDifficultyErrorMessage = "Invalid game difficulty!";
        private const string PlayAgainAnswerErrorMessage = "Invalid answer!";

        private const string GameModeInviteMessage = "Select a game mode: please type 'default' or 'fly': ";
        private const string GameDifficultyInviteMessage = "Select a game difficulty: please type 'easy' or 'hard': ";
        private const string PlayerResponseInviteMessage = "Do you want to play again? Please type 'yes' or 'no': ";
        private const string CommandInputInviteMessage = "Enter a command ('pop {row} {col}', 'top', 'save', 'restore', 'help', 'exit'): ";
        private const string PlayerInfoInviteMessage = "Please enter your name: ";

        public GameMode GetGameMode()
        {
            while (true)
            {
                Console.Write(GameModeInviteMessage);
                string input = Console.ReadLine();
                string gameModeAsString = input.Trim().ToLower();
                bool isValidGameMode = Validator.CheckIfValidGameMode(gameModeAsString);

                if (isValidGameMode)
                {
                    var gameMode = EnumUtils.GetGameModeFromString(gameModeAsString);
                    return gameMode;
                }
                else
                {
                    ConsoleHelper.DisplayInputErrorMessage(GameModeErrorMessage);
                }
            }
        }

        public GameDifficulty GetGameDifficulty()
        {
            while (true)
            {
                Console.Write(GameDifficultyInviteMessage);
                string input = Console.ReadLine();
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
                    ConsoleHelper.DisplayInputErrorMessage(GameDifficultyErrorMessage);
                }
            }
        }

        public AnotherRound GetPlayAgainResponse()
        {
            while (true)
            {
                Console.Write(PlayerResponseInviteMessage);
                string input = Console.ReadLine();
                string answerAsString = input.Trim().ToLower();
                bool isValidAnswer = Validator.CheckIfValidAnswer(answerAsString);
                if (isValidAnswer)
                {
                    var answer = EnumUtils.GetPlayAgainAnswerFromString(answerAsString);
                    return answer;
                }
                else
                {
                    ConsoleHelper.DisplayInputErrorMessage(PlayAgainAnswerErrorMessage);
                }
            }
        }

        public string ReadInputCommand()
        {
            Console.Write(CommandInputInviteMessage);
            string userInput = Console.ReadLine().Trim().ToLower();

            return userInput;
        }
        public string ReadPlayerInfo()
        {
            Console.Write(PlayerInfoInviteMessage);
            string playerName = Console.ReadLine();

            return playerName;
        }

        public bool IsValidInput(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                return false;
            }

            return true;
        }

        public bool IsPositionValid(int row, int col, IGameField gameField)
        {
            bool validRow = (row >= 0) && (row <= gameField.Rows);
            bool validColumn = (col >= 0) && (col <= gameField.Columns);

            if (validRow && validColumn)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
