namespace Balloons.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Balloons.Common;
    using Balloons.FieldFactory.Field;
    using Balloons.GamePlayer;
    using Balloons.Helpers;

    public class ConsoleRenderer : IRenderer
    {
        private const char TopAndBottomBorderSymbol = '-';
        private const string FieldLeftBorderSymbol = "{0} | ";
        private const string FieldRigthBorderSymbol = "| ";
        private const string Indent = "   ";
        private const string PlayersTemplateString = "{0}. {1} made {2} moves";

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

        public void RenderGameMessage(string message)
        {
            ConsoleHelper.CentraliseCursor(message.Length);
            Console.WriteLine(message);
        }

        public void RenderCommands(string[] commands)
        {
            int commandMaxLength = commands.Max(m => m.Length);
            for (int i = 0; i < commands.Length; i++)
            {
                ConsoleHelper.CentraliseCursor(commandMaxLength);
                Console.WriteLine(commands[i]);
            }
        }

        public void RenderGameTopPlayers(IList<IPlayer> players)
        {
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine(PlayersTemplateString, i + 1, players[i].Name, players[i].Moves);
            }
        }

        public void RenderGameErrorMessage(string message)
        {
            ConsoleHelper.DisplayInputErrorMessage(message);
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
                    string symbol = field[row, column].Symbol;
                    BalloonsColors symbolColor = field[row, column].Color;

                    ConsoleHelper.ChangeForegroundColorDependingOnSymbol(symbolColor);
                    Console.Write(field[row, column].Symbol + " ");
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
            int commandMaxLength = commands.Max(m => m.Length);
            for (int i = 0; i < commands.Length; i++)
            {
                ConsoleHelper.CentraliseCursor(commandMaxLength);
                Console.WriteLine(commands[i]);
            }
        }
    }
}
