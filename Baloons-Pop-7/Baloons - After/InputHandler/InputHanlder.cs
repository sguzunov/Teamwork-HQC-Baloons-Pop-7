namespace Balloons.InputHandler
{
    using System;
    using System.Text;
    using Balloons.Commands;
    using Balloons.Common;
    using Balloons.ConsoleUI;
    using Balloons.GameField;
    using Balloons.GameRules;
    using Balloons.Logic;

    public class InputHanlder
    {
        private static int moves = 0;
        private static MemoryManager gameMemory = new MemoryManager();
        private static bool isUndo = false;
        public static StringBuilder userInput = new StringBuilder();


        private static void ReadTheIput()
        {
            if (!PopBalloons.IsFinished())
            {
                Console.Write(GameMessages.CELL_INPUT_MESSAGE);
                userInput.Append(Console.ReadLine());
            }
            else
            {
                Console.Write("Good Job! You popped all baloons in " + moves + " moves."
                                 + "Please enter your name for the top scoreboard:");
                userInput.Append(Console.ReadLine());
                StatisticsCommand.Add(moves, userInput.ToString());
                StatisticsCommand.Show();
                userInput.Clear();
                moves = 0;
                UndoCommand.ClearMemory(gameMemory);
                StartCommand.Start();
            }
        }

        private static void PlayGame()
        {
            int i = -1;
            int j = -1;

            ReadTheIput();

            string input = userInput.ToString();

            if (userInput.ToString() == "")
            {
                InvalidCommand.DisplayMessage();
                userInput.Clear();
                GameLogic(userInput);
            }

            if (userInput.ToString() == "top")
            {
                StatisticsCommand.Show();
                userInput.Clear();
                ReadTheIput();
            }
            if (userInput.ToString() != "undo")
            {
                isUndo = false;
            }          
            if (userInput.ToString() == "undo")
            {
                isUndo = true;

                try
                {
                   var memory = UndoCommand.Load(gameMemory);
                   Field.gameField = memory.GameField;
                   moves = memory.Moves;
                   PopBalloons.filledCells = memory.FilledCells;
                }
                catch (InvalidOperationException)
                {
                    InvalidCommand.DisplayMessage();
                    userInput.Clear();
                    GameLogic(userInput);
                }
                
                FieldDrawer.Draw(Field.gameField, GameConstants.WIDTH_OF_FIELD, GameConstants.HEIGHT_OF_FIELD);
                userInput.Clear();
                GameLogic(userInput);
            }
            if (userInput.ToString() == "restart")
            {
                userInput.Clear();
                RestartCommand.Restart();
            }
            if (userInput.ToString() == "exit")
            {
                ExitCommand.Exit();
            }

            if (!isUndo)
            {
                UndoCommand.Save(Field.gameField, gameMemory, moves,PopBalloons.filledCells);
            }

            string activeCell;
            userInput.Replace(" ", "");
            try
            {
                i = Int32.Parse(userInput.ToString()) / 10;
                j = Int32.Parse(userInput.ToString()) % 10;
            }
            catch (Exception)
            {
                InvalidCommand.DisplayMessage();
                userInput.Clear();
                GameLogic(userInput);
            }
            if (CheckConditionLegalMove.IsLegalMove(i, j))
            {
                activeCell = Field.gameField[i, j];
                PopBalloons.Clear(i, j, activeCell);
            }
            else
            {
                InvalidMove.DisplayMessage();
                userInput.Clear();
                GameLogic(userInput);
            }

            RemoveBallonsCommand.RemovePoppedBaloons(Field.gameField);

            FieldDrawer.Draw(Field.gameField, GameConstants.WIDTH_OF_FIELD, GameConstants.HEIGHT_OF_FIELD);

        }

        public static void GameLogic(StringBuilder userInput)
        {         
            PlayGame();
            moves++;
            userInput.Clear();
            GameLogic(userInput);
        }
    }
}
