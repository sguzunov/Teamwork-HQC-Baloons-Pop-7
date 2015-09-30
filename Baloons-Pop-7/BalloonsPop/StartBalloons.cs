namespace Balloons
{
    using System;

    using Balloons.Commands;
    using System.Linq;
    using Balloons.GameField;
    using Balloons.UI;
    using Balloons.GamePlayer;
    using Balloons.GameFieldFactories;
    using Balloons.Common;
    using System.Text;
    using Balloons.Logic;
    using Balloons.GameRules;
    using Balloons.InputHandler;

    public class StartBalloons
    {
         
        //private static int moves = 0;
        //private static MemoryManager gameMemory = new MemoryManager();
        //private static bool isUndo = false;
        //public static StringBuilder userInput = new StringBuilder();

        public static void Main(string[] args)
        {
            //StartCommand.Start();

            // creating game field...
            IGameField field = GameFieldFactory.CreateGameField(GameType.Hard);
            field.Fill();
            var renderer = new ConsoleRenderer();
            renderer.RenderGameField(field);
            Console.Write(GameMessages.CELL_INPUT_MESSAGE);

            /// input handler
            var inputHandler = new ConsoleInputHandler();
            string input = inputHandler.ReadInput();
            string parsedInput = inputHandler.ParseInput(input);
            Console.WriteLine(input);
            Console.WriteLine(parsedInput);
        }

        //private static void ReadTheIput()
        //{
        //    if (!PopBalloons.IsFinished())
        //    {
        //        Console.Write(GameMessages.CELL_INPUT_MESSAGE);
        //        userInput.Append(Console.ReadLine());
        //    }
        //    else
        //    {
        //        Console.Write("Good Job! You popped all baloons in " + moves + " moves."
        //                         + "Please enter your name for the top scoreboard:");
        //        userInput.Append(Console.ReadLine());
        //        StatisticsCommand.Add(moves, userInput.ToString());
        //        StatisticsCommand.Show();
        //        userInput.Clear();
        //        moves = 0;
        //        UndoCommand.ClearMemory(gameMemory);
        //        StartCommand.Start();
        //    }
        //}

        //private static void PlayGame()
        //{
        //    int i = -1;
        //    int j = -1;

        //    ReadTheIput();

        //    string input = userInput.ToString();

        //    if (userInput.ToString() == "")
        //    {
        //        InvalidCommand.DisplayMessage();
        //        userInput.Clear();
        //        GameLogic(userInput);
        //    }

        //    if (userInput.ToString() == "top")
        //    {
        //        StatisticsCommand.Show();
        //        userInput.Clear();
        //        ReadTheIput();
        //    }
        //    if (userInput.ToString() != "undo")
        //    {
        //        isUndo = false;
        //    }
        //    if (userInput.ToString() == "undo")
        //    {
        //        isUndo = true;

        //        try
        //        {
        //            var memory = UndoCommand.Load(gameMemory);
        //            Field.gameField = memory.GameField;
        //            moves = memory.Moves;
        //            PopBalloons.filledCells = memory.FilledCells;
        //        }
        //        catch (InvalidOperationException)
        //        {
        //            InvalidCommand.DisplayMessage();
        //            userInput.Clear();
        //            GameLogic(userInput);
        //        }

        //        FieldDrawer.Draw(Field.gameField, GameConstants.WIDTH_OF_FIELD, GameConstants.HEIGHT_OF_FIELD);
        //        userInput.Clear();
        //        GameLogic(userInput);
        //    }
        //    if (userInput.ToString() == "restart")
        //    {
        //        userInput.Clear();
        //        RestartCommand.Restart();
        //    }
        //    if (userInput.ToString() == "exit")
        //    {
        //        ExitCommand.Exit();
        //    }

        //    if (!isUndo)
        //    {
        //        UndoCommand.Save(Field.gameField, gameMemory, moves, PopBalloons.filledCells);
        //    }

        //    string activeCell;
        //    userInput.Replace(" ", "");
        //    try
        //    {
        //        i = Int32.Parse(userInput.ToString()) / 10;
        //        j = Int32.Parse(userInput.ToString()) % 10;
        //    }
        //    catch (Exception)
        //    {
        //        InvalidCommand.DisplayMessage();
        //        userInput.Clear();
        //        GameLogic(userInput);
        //    }
        //    if (CheckConditionLegalMove.IsLegalMove(i, j))
        //    {
        //        activeCell = Field.gameField[i, j];
        //        PopBalloons.Clear(i, j, activeCell);
        //    }
        //    else
        //    {
        //        InvalidMove.DisplayMessage();
        //        userInput.Clear();
        //        GameLogic(userInput);
        //    }

        //    RemoveBallonsCommand.RemovePoppedBaloons(Field.gameField);

        //    FieldDrawer.Draw(Field.gameField, GameConstants.WIDTH_OF_FIELD, GameConstants.HEIGHT_OF_FIELD);

        //}

        //public static void GameLogic(StringBuilder userInput)
        //{
        //    PlayGame();
        //    moves++;
        //    userInput.Clear();
        //    GameLogic(userInput);
        //}
    }
}
