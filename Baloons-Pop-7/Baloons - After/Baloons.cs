namespace Baloons
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Common;
    using Commands;
    using Logic;
    using GameRules;

    public class Baloons
    {

        private static int counter = 0;
        public static StringBuilder userInput = new StringBuilder();

        public static void Start()
        {
            Console.WriteLine(GameMessages.INITIAL_GAME_MESSAGE);


            GameField.gameField = GameField.InitialGameField(GameConstants.WIDTH, GameConstants.HEIGHT);
            GameField.Draw(GameField.gameField, GameConstants.WIDTH, GameConstants.HEIGHT);

            GameLogic(userInput);
        }

        public static void GameLogic(StringBuilder userInput)
        {
            PlayGame();
            counter++;
            userInput.Clear();
            GameLogic(userInput);
        }

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
                Start();
            }
        }

        private static void PlayGame()
        {
            int i = -1;
            int j = -1;

            //        Play:
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

            remove();

            GameField.Draw(GameField.gameField, GameConstants.WIDTH, GameConstants.HEIGHT);
        }



        private static void remove()
        {
            int i;
            Queue<string> temp = new Queue<string>();
            for (int j = GameConstants.HEIGHT - 1; j >= 0; j--)
            {
                for (i = GameConstants.WIDTH - 1; i >= 0; i--)
                {
                    if (GameField.gameField[i, j] != ".")
                    {
                        temp.Enqueue(GameField.gameField[i, j]);
                        GameField.gameField[i, j] = ".";
                    }
                }
                i = 4;
                while (temp.Count > 0)
                {
                    GameField.gameField[i, j] = temp.Dequeue();
                    i--;
                }
                temp.Clear();
            }
        }
    }
}
