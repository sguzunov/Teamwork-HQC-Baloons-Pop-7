namespace Balloons.InputHandler
{
    using System;
    using Balloons.FieldFactory.Field;
    using Balloons.Commands;
    using Balloons.Common;
    using Balloons.Helpers;
    using System.Threading;

    public class ConsoleInputHandler : IInputHandler
    {
        private const string GameModeErrorMessage = "Invalid game mode!";
        private const string GameDifficultyErrorMessage = "Invalid game difficulty!";

        public string ReadInputCommand()
        {
            Console.Write("Enter a command ('top', 'save', 'restore', 'help', 'exit'): ");
            string input = Console.ReadLine();

            if (Validator.CheckIfStringIsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input command cannot be null or empty space.");
            }

            string command = input.Trim().ToLower();

            return command;
        }

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

        private readonly string[] validCommands = new string[]
            {
                "help",
                "start",
                "exit",
                "restart",
                "top",
                "undo",
            };

        /// <summary>
        /// This method reads the input from the console
        /// </summary>
        /// <returns>command as string</returns>
        public string ReadInput()
        {
            string userInput = Console.ReadLine();

            if (IsValidInput(userInput))
            {
                return userInput;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Check if the command is valid, i.e. if it is not empty
        /// </summary>
        /// <param name="command">string result of the method Read()</param>
        /// <returns>bool value indicating if the command is valid</returns>
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


        /// <summary>
        /// Parse the user input
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns>command that can be interpreted by the engine</returns>
        public string ParseInput(string userInput, IGameField gameField)
        {
            string command;
            string[] commandArray = userInput.Split(' ');
            int userInputLength = commandArray.Length;
            int row;
            int col;

            if (CheckIfValid(userInput, this.validCommands))
            {
                command = commandArray[0];
            }
            // maybe a bool variable should be pulled out
            else if (userInputLength == PopCommandLength &&
                int.TryParse(commandArray[0].ToString(), out row) &&
                int.TryParse(commandArray[1].ToString(), out col))
            {
                if (IsPositionValid(row, col, gameField))
                {
                    command = "pop " + (row - 1).ToString() + " " + (col - 1).ToString();
                }
                else
                {
                    command = "pop invalid";
                }
            }
            else
            {
                command = string.Empty;
            }

            return command;
        }

        public string ParseInput(string userInput, string[] commands)
        {
            string command;
            string[] commandArray = userInput.Split(' ');
            int userInputLength = commandArray.Length;

            if ((CheckIfValid(userInput, commands)))
            {
                command = commandArray[0];
            }
            else
            {
                command = string.Empty;
            }

            return command;
        }

        public bool CheckIfValid(string input, string[] commands)
        {
            string[] inputSplit = input.ToLower().Split(' ');
            bool validCommand = false;

            if (inputSplit.Length == 1)
            {
                if (Array.IndexOf(commands, inputSplit[0]) >= 0)
                {
                    validCommand = true;
                }
                else
                {
                    validCommand = false;
                }
            }

            return validCommand;
        }
    }
}
