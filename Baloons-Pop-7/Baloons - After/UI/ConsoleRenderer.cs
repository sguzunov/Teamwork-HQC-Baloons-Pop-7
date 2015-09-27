namespace Balloons.UI
{
    using System;
    using System.Linq;

    using Balloons.GameField;

    public class ConsoleRenderer : IRenderer
    {
        public void RenderGameField(IGameField field)
        {
            int rows = field.Rows;
            int columns = field.Columns;

            Console.Write("   ");
            for (int i = 0; i < columns; i++)
            {
                Console.Write(" {0}", i + 1);
            }

            Console.WriteLine();

            this.PrintBorder(columns);

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

            this.PrintBorder(columns);
        }

        private void PrintBorder(int columns)
        {
            Console.Write("   ");
            Console.WriteLine(new string('-', columns * 2));
        }
    }
}
