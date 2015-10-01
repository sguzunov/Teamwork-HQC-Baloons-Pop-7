namespace Balloons.InputHandler
{
    using System;
    using Balloons.GameField;
    using BalloonsPop.Commands;

    public class ConsoleInputHandler : IInputHandler
    {
        private readonly string[] validCommands = new string[]
            {
                "help",
                "start",
                "exit",
                "restart",
                "top",
                "undo"
            };

        ICommand cmd = null;

        /// <summary>
        /// This method reads the input from the console
        /// </summary>
        /// <returns>command as string</returns>
        public string ReadInput()
        {
            string userInput = Console.ReadLine();

            if (IsValidInput(userInput))
            {
                return string.Empty;
            }
            else
            {
                return userInput;
            }
        }

        /// <summary>
        /// Check if the command is valid, i.e. if it is not empty
        /// </summary>
        /// <param name="command">string result of the method Read()</param>
        /// <returns>bool value indicating if the command is valid</returns>
        public bool IsValidInput(string command)
        {
            bool validCommand = true;

            if (command != string.Empty)
            {
                validCommand = false;
            }

            return validCommand;
        }

        internal static bool IsPositionValid(int row, int col, IGameField gameField)
        {
            bool validRow = (row >= 0) && (row < gameField.Rows);
            bool validColumn = (col >= 0) && (col < gameField.Columns);

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
            var inputSplit = userInput.ToLower().Split(' ');

            int row;
            int col;
            string command;

            if (inputSplit.Length == 1)
            {
                if (Array.IndexOf(this.validCommands, inputSplit[0]) >= 0)
                {
                    command = inputSplit[0];
                }
                else
                {
                    command = string.Empty;
                }
            }
            else if (inputSplit.Length == 2 &&
                int.TryParse(inputSplit[0].ToString(), out row) &&
                int.TryParse(inputSplit[1].ToString(), out col))
            {
                if (IsPositionValid(row, col, gameField))
                {
                    command = "pop " + row.ToString() + " " + col.ToString();
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

        // this is the invoker class (command pattern)
        public ICommand GetCommand(string action)
        {
            string command = action.Split(' ')[0];

            switch (command)
            {
                case "exit":
                    cmd = new ExitCommand();
                    break;
                case "top":
                    cmd = new ShowScoreboardCommand();
                    break;
                case "undo":
                    cmd = new UndoCommand();
                    break;
                case "help":
                    cmd = new HelpCommand();
                    break;
                case "start":
                    cmd = new StartCommand();
                    break;
                case "restart":
                    cmd = new StartCommand();
                    break;

                case "pop":
                    if (action.Split(' ')[1] == "invalid")
                    {
                        cmd = new InvalidCommand();
                    }
                    else
                    {
                        cmd = new PopBalloonsCommand();
                    }
                    break;

                case "":
                    cmd = new InvalidPopCommand();
                    break;
                default:
                    break;
            }
            return cmd;
        }
    }
}
