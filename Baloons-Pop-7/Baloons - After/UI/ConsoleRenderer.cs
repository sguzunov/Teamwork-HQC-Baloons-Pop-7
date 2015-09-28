namespace Balloons.UI
{
    using System;
    using System.Linq;

    using Balloons.Common;
    using Balloons.GameField;
    using Balloons.Helpers;

    public class ConsoleRenderer : IRenderer
    {
        public void RenderGameField(IGameField field)
        {
            int columns = field.Columns;

            Console.Write("   ");
            for (int i = 0; i < columns; i++)
            {
                Console.Write(" {0}", i + 1);
            }

            Console.WriteLine();

            this.PrintBorder(columns);

            this.PrintMatrix(field);

            this.PrintBorder(columns);
        }

        public void RenderMenu()
        {
            ConsoleHelper.CentraliseCursor(GameMessages.InitialGameMessage.Length);
            Console.WriteLine(GameMessages.InitialGameMessage);

            this.PrintCommands(GameMessages.CommandsMessages);
        }

        public void RenderGameScoreBoard()
        {
            throw new NotImplementedException();
        }

        private void PrintMatrix(IGameField field)
        {
            int rows = field.Rows;
            int columns = field.Columns;

            for (int row = 0; row < rows; row++)
            {
                Console.Write("{0} | ", row + 1);
                for (int column = 0; column < columns; column++)
                {
                    if (field[row, column] == ".")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(field[row, column] + " ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(field[row, column] + " ");
                    }
                }

                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write("| ");
                Console.WriteLine();
            }
        }

        private void PrintCommands(string[] commands)
        {
            int textMaxLength = commands.Max(m => m.Length);
            for (int i = 0; i < commands.Length; i++)
            {
                ConsoleHelper.CentraliseCursor(textMaxLength);
                Console.WriteLine(commands[i]);
            }
        }

        private void PrintBorder(int columns)
        {
            Console.Write("   ");
            Console.WriteLine(new string('-', columns * 2));
        }
    }
}
