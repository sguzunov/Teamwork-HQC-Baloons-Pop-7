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
            throw new NotImplementedException();
        }

        public GameMode GetGameMode()
        {
            while (true)
            {
                Console.Write("Select a game mode: please type 'default' or 'fly': ");
                string gameModeAsString = Console.ReadLine().Trim().ToLower();

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
                string gameDifficultyAsString = Console.ReadLine().Trim().ToLower();

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

        //const int PopCommandLength = 2;

        //private readonly string[] validCommands = new string[]
        //    {
        //        "help",
        //        "start",
        //        "exit",
        //        "restart",
        //        "top",
        //        "undo",
        //    };

        //private readonly string[] validModes = new string[]
        //    {
        //        "fly",
        //        "default"
        //    };

        //private readonly string[] validTypes = new string[]
        //    {
        //        "easy",
        //        "hard"
        //    };

        //ICommand cmd = null;

        //public GameMode SetMode()
        //{
        //    GameMode gameMode = GameMode.Invalid;

        //    string input = string.Empty;
        //    string parsedInput = string.Empty;

        //    do
        //    {
        //        Console.WriteLine("Choose a mode: please type 'default' or 'fly': ");
        //        input = ReadInput();
        //        parsedInput = ParseInput(input, this.validModes);

        //        if (parsedInput == "fly")
        //        {
        //            gameMode = GameMode.Fly;
        //        }
        //        else if (parsedInput == "default")
        //        {
        //            gameMode = GameMode.Default;
        //        }
        //    }
        //    while ((gameMode == GameMode.Invalid));

        //    return gameMode;        
        //}

        //public GameType SetType()
        //{
        //    GameType gameType = GameType.Invalid;

        //    string input = string.Empty;
        //    string parsedInput = string.Empty;

        //    do
        //    {
        //        Console.WriteLine("Choose difficulty: please type 'easy' or 'hard': ");
        //        input = ReadInput();
        //        parsedInput = ParseInput(input, this.validTypes);

        //        if (parsedInput == "easy")
        //        {
        //            gameType = GameType.Easy;
        //        }
        //        else if (parsedInput == "hard")
        //        {
        //            gameType = GameType.Hard;
        //        }

        //    }
        //    while ((gameType == GameType.Invalid));       

        //    return gameType;
        //}

        ///// <summary>
        ///// This method reads the input from the console
        ///// </summary>
        ///// <returns>command as string</returns>
        //public string ReadInput()
        //{
        //    string userInput = Console.ReadLine();

        //    if (IsValidInput(userInput))
        //    {
        //        return userInput;                
        //    }
        //    else
        //    {
        //        return string.Empty;
        //    }
        //}

        ///// <summary>
        ///// Check if the command is valid, i.e. if it is not empty
        ///// </summary>
        ///// <param name="command">string result of the method Read()</param>
        ///// <returns>bool value indicating if the command is valid</returns>
        //public bool IsValidInput(string command)
        //{
        //    bool validCommand = true;

        //    if (string.IsNullOrWhiteSpace(command))
        //    {
        //        validCommand = false;
        //    }

        //    return validCommand;
        //}

        //public bool IsPositionValid(int row, int col, IGameField gameField)
        //{
        //    bool validRow = (row >= 0) && (row < gameField.Rows);
        //    bool validColumn = (col >= 0) && (col < gameField.Columns);

        //    if (validRow && validColumn)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}


        ///// <summary>
        ///// Parse the user input
        ///// </summary>
        ///// <param name="userInput"></param>
        ///// <returns>command that can be interpreted by the engine</returns>
        //public string ParseInput(string userInput, IGameField gameField)
        //{                       
        //    string command;
        //    string[] commandArray = userInput.Split(' ');
        //    int userInputLength = commandArray.Length;
        //    int row;
        //    int col;

        //    if (CheckIfValid(userInput, this.validCommands))
        //    {
        //        command = commandArray[0];
        //    }
        //        // maybe a bool variable should be pulled out
        //    else if (userInputLength == PopCommandLength &&
        //        int.TryParse(commandArray[0].ToString(), out row) &&
        //        int.TryParse(commandArray[1].ToString(), out col))
        //    {
        //        if (IsPositionValid(row, col, gameField))
        //        {
        //            command = "pop " + row.ToString() + " " + col.ToString();
        //        }
        //        else
        //        {
        //            command = "pop invalid";
        //        }
        //    }
        //    else
        //    {
        //        command = string.Empty;
        //    }

        //    return command;
        //}

        //public string ParseInput(string userInput, string[] commands)
        //{
        //    string command;
        //    string[] commandArray = userInput.Split(' ');
        //    int userInputLength = commandArray.Length;

        //    if ((CheckIfValid(userInput, commands)))
        //    {                
        //        command = commandArray[0];
        //    }
        //    else
        //    {
        //        command = string.Empty;
        //    }

        //    return command;
        //}

        //// this is the invoker class (command pattern)
        //public ICommand GetCommand(string action)
        //{
        //    string command = action.Split(' ')[0];

        //    switch (command)
        //    {
        //        case "exit":
        //            cmd = new ExitCommand();
        //            break;
        //        case "top":
        //            cmd = new ShowScoreboardCommand();
        //            break;
        //        case "undo":
        //            cmd = new UndoCommand();
        //            break;
        //        case "help":
        //            cmd = new HelpCommand();
        //            break;
        //        case "start":
        //            cmd = new StartCommand();
        //            break;
        //        case "restart":
        //            cmd = new StartCommand();
        //            break;

        //        case "pop":
        //            if (action.Split(' ')[1] == "invalid")
        //            {
        //                cmd = new InvalidCommand();
        //            }
        //            else
        //            {
        //                cmd = new PopBalloonsCommand();
        //            }
        //            break;

        //        case "":
        //            cmd = new InvalidPopCommand();
        //            break;
        //        default:
        //            cmd = new InvalidCommand();
        //            break;
        //    }
        //    return cmd;
        //}

        //public bool CheckIfValid(string input, string[] commands)
        //{
        //    string[] inputSplit = input.ToLower().Split(' ');
        //    bool validCommand = false;

        //    if (inputSplit.Length == 1)
        //    {
        //        if (Array.IndexOf(commands, inputSplit[0]) >= 0)
        //        {
        //            validCommand = true;
        //        }
        //        else
        //        {
        //            validCommand = false;
        //        }
        //    }

        //    return validCommand;
        //}
    }
}
