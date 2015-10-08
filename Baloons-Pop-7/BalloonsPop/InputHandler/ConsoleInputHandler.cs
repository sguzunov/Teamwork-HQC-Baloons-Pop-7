namespace Balloons.InputHandler
{
    using System;
    using System.Collections.Generic;

    using Balloons.Common;
    using Balloons.FieldFactory.Field;
    using Balloons.Helpers;

    public class ConsoleInputHandler : IInputHandler
    {
        private const string GameModeErrorMessage = "Invalid game mode!";
        private const string GameDifficultyErrorMessage = "Invalid game difficulty!";

        public GameMode GetGameMode()
        {
            while (true)
            {
                Console.Write("Select a game mode: please type 'default' or 'fly': ");
                string input = Console.ReadLine();

                if (Validator.CheckIfStringIsNullOrWhiteSpace(input))
                {
                    throw new ArgumentException("Input game mode cannot be null or empty space.");
                }

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
                Console.Write("Select a game difficulty: please type 'easy' or 'hard': ");
                string input = Console.ReadLine();

                if (Validator.CheckIfStringIsNullOrWhiteSpace(input))
                {
                    throw new ArgumentException("Input game difficulty cannot be null or empty space.");
                }

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

        const int PopCommandLength = 2;

        public IList<string> ReadInputCommand()
        {
            IList<string> commandList = new List<string>();

            Console.Write("Enter a command ('top', 'save', 'restore', 'help', 'exit'): ");
            string userInput = Console.ReadLine();

            if (IsValidInput(userInput))
            {
                string[] splittedCommands = userInput.ToLower().Split(' ');
                foreach (var c in splittedCommands)
                {
                    commandList.Add(c);
                }
            }
            else
            {
                commandList.Add("invalid");
            }

            return commandList;
        }

        public IList<string> ParseInput(IList<string> command, IGameField gameField)
        {
            IList<string> parsedCommand = command;
            int userInputLength = command.Count;
            Console.WriteLine(userInputLength);
            int row;
            int col;

            if (userInputLength == PopCommandLength &&
                int.TryParse(command[0].ToString(), out row) &&
                int.TryParse(command[1].ToString(), out col))
            {
                if (IsPositionValid(row, col, gameField))
                {
                    parsedCommand.Clear();
                    parsedCommand.Add("pop");
                    parsedCommand.Add((row - 1).ToString());
                    parsedCommand.Add((col - 1).ToString());
                }
                else
                {
                    parsedCommand.Add("invalid");
                    parsedCommand.Add("pop");
                }
            }

            return parsedCommand;
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
