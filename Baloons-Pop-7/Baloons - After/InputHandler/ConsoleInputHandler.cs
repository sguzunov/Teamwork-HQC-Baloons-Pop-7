namespace Balloons.InputHandler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ConsoleInputHandler : IInputHandler
    {
        private readonly string[] validCommands = new string[]
            {
                "save",
                "restore",
                "help",
                "exit",
                "restart",
                "top",
                "undo"
            };

        /// <summary>
        /// This method reads the input from the console
        /// </summary>
        /// <returns>command as string</returns>
        public string ReadInput()
        {
            string userInput = Console.ReadLine();

            if (!IsValidInput(userInput))
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

        /// <summary>
        /// Parse the user input
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns>command that can be interpreted by the engine</returns>
        public string ParseInput(string userInput)
        {
            var inputSplit = userInput.ToLower().Split(' ');

            int row;
            int col;
            string command;

            if (inputSplit.Length == 1)
            {
                if (Array.IndexOf(validCommands, inputSplit[0]) >= 0)
                {
                    command = inputSplit[0];
                }
                else
                {
                    command = string.Empty;
                }
            }

            else if ((int.TryParse(inputSplit[0].ToString(), out row)) && (int.TryParse(inputSplit[1].ToString(), out col)))
            {
                command = "pop " + row.ToString() + " " + col.ToString();
            }

            else
            {
                command = string.Empty;
            }

            return command;
        }
    }
}
