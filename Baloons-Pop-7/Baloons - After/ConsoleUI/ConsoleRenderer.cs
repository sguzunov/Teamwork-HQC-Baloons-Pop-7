namespace Balloons.ConsoleUI
{
    using System;
    using System.Linq;

    using Balloons.GameField;

    public class ConsoleRenderer : IRenderer
    {
        public void RenderGameField(IGameField field)
        {
            int rows = field.Columns;
            int columns = field.Rows;

            Console.Write("    ");
            for (int i = 0; i < columns; i++)
            {
                Console.Write(i);
            }

            this.PrintBorder(columns);

            for (int row = 0; row < rows; row++)
            {
                Console.Write(row + " | ");

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

                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("| ");
                Console.WriteLine();
            }

            this.PrintBorder(columns);
        }

        private void PrintBorder(int columns)
        {
            Console.Write("   ");
            Console.Write(string.Concat(Enumerable.Repeat("-", columns)));
        }
    }
}
