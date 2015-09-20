namespace Balloons
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;

    using Balloons.Common;

    public class Baloons
    {
        const int WIDTH = 5;
        const int HEIGHT = 10;

        private static int filledCells;
        private static int counter = 0;
        private static int clearedCells = 0;
        public static string[,] gameField = new string[WIDTH, HEIGHT];
        public static StringBuilder userInput = new StringBuilder();

        public static void Start()
        {
            Console.WriteLine(GameMessages.INITIAL_GAME_MESSAGE);
            filledCells = WIDTH * HEIGHT;
            counter = 0;
            clearedCells = 0;

            GameField.Draw(gameField, WIDTH, HEIGHT);

            GameLogic(userInput);
        }

        public static void GameLogic(StringBuilder userInput)
        {
            PlayGame();
            counter++;
            userInput.Clear();
            GameLogic(userInput);


        }
        private static bool IsLegalMove(int i, int j)
        {
            if ((i < 0) || (j < 0) || (j > HEIGHT - 1) || (i > WIDTH - 1))
                return false;
            else
                return (gameField[i, j] != ".");
        }

        private static void Error()
        {
            Console.WriteLine(GameMessages.INVALID_COMMAND_MESSAGE);
            userInput.Clear();
            GameLogic(userInput);
        }

        private static void InvalidMove()
        {
            Console.WriteLine(GameMessages.INVALID_MOVE_MESSAGE);
            userInput.Clear();
            GameLogic(userInput);

        }

        private static void Exit()
        {
            Console.WriteLine(GameMessages.END_GAME_MESSAGE);
            Thread.Sleep(1000);
            Console.WriteLine(counter.ToString());
            Console.WriteLine(filledCells.ToString());
            Environment.Exit(0);
        }

        private static void Restart()
        {
            Start();
        }

        private static void ReadTheIput()
        {
            if (!IsFinished())
            {
                Console.Write(GameMessages.CELL_INPUT_MESSAGE);
                userInput.Append(Console.ReadLine());
            }
            else
            {
                Console.Write("Good Job! You popped all baloons in " + counter + " moves."
                                 + "Please enter your name for the top scoreboard:");
                userInput.Append(Console.ReadLine());
                Statistics.statistics.Add(counter, userInput.ToString());
                Statistics.Show();
                userInput.Clear();
                Start();
            }
        }

        private static void PlayGame()
        {
            int i = -1;
            int j = -1;

        Play:
            ReadTheIput();

            string hop = userInput.ToString();

            if (userInput.ToString() == "")
                Error();
            if (userInput.ToString() == "top")
            {
                Statistics.Show();
                userInput.Clear();
                goto Play;
            }
            if (userInput.ToString() == "restart")
            {
                userInput.Clear();
                Restart();
            }
            if (userInput.ToString() == "exit")
                Exit();

            string activeCell;
            userInput.Replace(" ", "");
            try
            {
                i = Int32.Parse(userInput.ToString()) / 10;
                j = Int32.Parse(userInput.ToString()) % 10;
            }
            catch (Exception)
            {
                Error();
            }
            if (IsLegalMove(i, j))
            {
                activeCell = gameField[i, j];
                clear(i, j, activeCell);
            }
            else
                InvalidMove();
            remove();
            Console.WriteLine("    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int row = 0; row < WIDTH; row++)
            {
                Console.Write(row + " | ");

                for (int col = 0; col < HEIGHT; col++)
                {
                    Console.Write(gameField[row, col] + " ");
                }
                Console.Write("| ");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------");
        }

        private static void clear(int i, int j, string activeCell)
        {
            if ((i >= 0) && (i <= 4) && (j <= 9) && (j >= 0) && (gameField[i, j] == activeCell))
            {
                gameField[i, j] = ".";
                clearedCells++;
                //Up
                clear(i - 1, j, activeCell);
                //Down
                clear(i + 1, j, activeCell);
                //Left
                clear(i, j + 1, activeCell);
                //Right
                clear(i, j - 1, activeCell);
            }
            else
            {
                filledCells -= clearedCells;
                clearedCells = 0;
                return;
            }
        }

        private static void remove()
        {
            int i;
            Queue<string> temp = new Queue<string>();
            for (int j = HEIGHT - 1; j >= 0; j--)
            {
                for (i = WIDTH - 1; i >= 0; i--)
                {
                    if (gameField[i, j] != ".")
                    {
                        temp.Enqueue(gameField[i, j]);
                        gameField[i, j] = ".";
                    }
                }
                i = 4;
                while (temp.Count > 0)
                {
                    gameField[i, j] = temp.Dequeue();
                    i--;
                }
                temp.Clear();
            }
        }
        private static bool IsFinished()
        {
            return (filledCells == 0);
        }
    }



    public class StartBaloons
    {

        static void Main(string[] args)
        {
            Baloons.Start();
        }
    }
}
