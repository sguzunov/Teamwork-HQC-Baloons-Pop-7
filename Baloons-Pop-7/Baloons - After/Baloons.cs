
namespace BalloonsPops
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;


    public class Baloons
    {
        const int WIDTH = 5;
        const int HEIGHT = 10;

        private static int filledCells;
        private static int counter = 0; 
        private static int clearedCells = 0;
        public static string[,] gameField = new string[WIDTH, HEIGHT];
        public static StringBuilder tmp = new StringBuilder();
        private static SortedDictionary<int, string> statistics = new SortedDictionary<int, string>();

        public static void Start()
        {
            Console.WriteLine("Welcome to “Balloons Pops” game. Please try to pop the balloons. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
            filledCells= WIDTH * HEIGHT;
            counter = 0;
            clearedCells = 0;

            for (int row = 0; row < WIDTH; row++)
            {
                for (int col = 0; col < HEIGHT; col++)
                {
                    gameField[row, col] = RamdomGenerator.GetRandomInt();
                }
            }
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
            GameLogic(tmp);
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
            Console.WriteLine("Invalid move or command");
            tmp.Clear();
            GameLogic(tmp);
        }

        private static void InvalidMove()
        {
            Console.WriteLine("Illegal move: cannot pop missing ballon!");
            tmp.Clear();
            GameLogic(tmp);


        }

        private static void ShowStatistics()
        {
            PrintAgain();
        }

        private static void Exit()
        {
            Console.WriteLine("Good Bye");
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
                Console.Write("Enter a row and column: ");
                tmp.Append(Console.ReadLine());
            }
            else
            {
                Console.Write("Good Job! You popped all baloons in " + counter + " moves."
                                 + "Please enter your name for the top scoreboard:");
                tmp.Append(Console.ReadLine());
                statistics.Add(counter, tmp.ToString());
                PrintAgain();
                tmp.Clear();
                Start();
            }
        }

        private static void PrintAgain()
        {
            int position = 0;



            Console.WriteLine("Scoreboard:");
            foreach (KeyValuePair<int, string> statistic in statistics)
            {
                if (position == 4)
                    break;
                else
                {
                    position++;
                    Console.WriteLine("{0}. {1} --> {2} moves", position, statistic.Value, statistic.Key);
                }
            }
        }
        private static void PlayGame()
        {
            int i = -1;
            int j = -1;

        Play:
            ReadTheIput();

            string hop = tmp.ToString();

            if (tmp.ToString() == "")
                Error();
            if (tmp.ToString() == "top")
            {
                ShowStatistics();
                tmp.Clear();
                goto Play;
            }
            if (tmp.ToString() == "restart")
            {
                tmp.Clear();
                Restart();
            }
            if (tmp.ToString() == "exit")
                Exit();

            string activeCell;
            tmp.Replace(" ", "");
            try
            {
                i = Int32.Parse(tmp.ToString()) / 10;
                j = Int32.Parse(tmp.ToString()) % 10;
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
                filledCells-= clearedCells;
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

    public static class RamdomGenerator
    {

        static Random r = new Random();
        public static string GetRandomInt()
        {
            string legalChars = "1234";
            string builder = null;
            builder = legalChars[r.Next(0, legalChars.Length)].ToString();
            return builder;
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
