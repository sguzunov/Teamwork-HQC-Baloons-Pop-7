namespace Balloons.UI
{
    using System;
    using System.Linq;

    using Balloons.Common;
    using Balloons.GameField;
    using Balloons.Helpers;

    public class ConsoleRenderer : IRenderer
    {
        private const char TopAndBottomBorderSymbol = '-';
        private const string FieldLeftBorderSymbol = "{0} | ";
        private const string FieldRigthBorderSymbol = "| ";
        private const string Indent = "   ";

        public void RenderGameField(IGameField field)
        {
            int columns = field.Columns;

            // Prints columns index
            Console.Write(Indent);
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

        public void RenderCommands()
        {
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
                // Prints rows index                
                Console.Write(FieldLeftBorderSymbol, row + 1);

                for (int column = 0; column < columns; column++)
                {
                    string symbol = field[row, column];
                    if (symbol == ".")
                    {
                        ConsoleHelper.ChangeForegroundColorDependingOnSymbol(symbol);
                        Console.Write(field[row, column] + " ");
                    }
                    else
                    {
                        ConsoleHelper.ChangeForegroundColorDependingOnSymbol(symbol);
                        Console.Write(field[row, column] + " ");
                    }
                }

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(FieldRigthBorderSymbol);
                Console.WriteLine();
            }
        }

        private void PrintBorder(int columns)
        {
            Console.Write(Indent);
            Console.WriteLine(new string(TopAndBottomBorderSymbol, columns * 2));
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
    }
}
