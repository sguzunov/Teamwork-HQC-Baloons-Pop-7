namespace Balloons.InputHandler
{
    using System;
    using System.Text;

    using Balloons.Commands;
    using Balloons.Common;
    using Balloons.GameField;
    using Balloons.GameRules;
    using Balloons.Logic;

    public class InputHanlder
    {
        private static int counter = 0;
        public static StringBuilder userInput = new StringBuilder();

        private static void ReadTheIput()
        {
            if (!PopBaloons.IsFinished())
            {
                Console.Write(GameMessages.CELL_INPUT_MESSAGE);
                userInput.Append(Console.ReadLine());
            }
            else
            {
                Console.Write("Good Job! You popped all baloons in " + counter + " moves."
                                 + "Please enter your name for the top scoreboard:");
                userInput.Append(Console.ReadLine());
                StatisticsCommand.statistics.Add(counter, userInput.ToString());
                StatisticsCommand.Show();
                userInput.Clear();
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
            if (userInput.ToString() == "restart")
            {
                userInput.Clear();
                RestartCommand.Restart();
            }
            if (userInput.ToString() == "exit")
            {
                ExitCommand.Exit();
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
                activeCell = GameField.gameField[i, j];
                PopBaloons.Clear(i, j, activeCell);
            }
            else
            {
                InvalidMove.DisplayMessage();
                userInput.Clear();
                GameLogic(userInput);
            }

            GameField.RemovePoppedBaloons();

            GameField.Draw(GameField.gameField, GameConstants.WIDTH, GameConstants.HEIGHT);
        }

        public static void GameLogic(StringBuilder userInput)
        {
            PlayGame();
            counter++;
            userInput.Clear();
            GameLogic(userInput);
        }
    }
}
