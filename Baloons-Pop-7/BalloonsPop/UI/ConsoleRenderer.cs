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
        private const string FieldNullErrorMessage = "Field cannot be null!";
        private const string FieldCellNullErrorMessage = "Field cell cannot be null!";
        private const string PlayersNullErrorMessage = "Players list cannot be null!";
        private const string CommandsCountErrorMessage = "Commands count cannot be less than one!";

        private const char TopAndBottomBorderSymbol = '-';
        private const string FieldLeftBorderSymbol = "{0} | ";
        private const string FieldRigthBorderSymbol = "| ";
        private const string Indent = "   ";
        private const string PlayersTemplateString = "{0}. {1} made {2} moves";

        private readonly IConsoleWriter consoleWriter;

        public ConsoleRenderer()
            : this(new ConsoleWriter())
        {
        }

        public ConsoleRenderer(IConsoleWriter consoleWriter)
        {
            this.consoleWriter = consoleWriter;
        }

        public void RenderGameField(IGameField field)
        {
            if (ObjectValidator.IsGameObjectNull(field))
            {
                throw new ArgumentNullException(FieldNullErrorMessage);
            }

            int columns = field.Columns;

            // Prints columns index
            this.consoleWriter.Write(Indent);
            for (int i = 0; i < columns; i++)
            {
                this.consoleWriter.Write(" {0}", i + 1);
            }

            Console.WriteLine();

            this.PrintBorder(columns);
            this.PrintMatrix(field);
            this.PrintBorder(columns);
        }

        public void RenderGameMessage(string message)
        {
            ConsoleHelper.CentraliseCursor(message.Length);
            this.consoleWriter.WriteLine(message);
        }

        public void RenderCommands(string[] commands)
        {
            if (commands.Length < 1)
            {
                throw new IndexOutOfRangeException(CommandsCountErrorMessage);
            }

            int commandMaxLength = commands.Max(m => m.Length);
            for (int i = 0; i < commands.Length; i++)
            {
                ConsoleHelper.CentraliseCursor(commandMaxLength);
                this.consoleWriter.WriteLine(commands[i]);
            }
        }

        public void RenderGameTopPlayers(IList<IPlayer> players)
        {
            if (players == null)
            {
                throw new ArgumentNullException(PlayersNullErrorMessage);
            }

            int maxPlayerNameLength = players.Max(p => p.Name.Length);
            int lengthForCentralizing = PlayersTemplateString.Length + maxPlayerNameLength;
            for (int i = 0; i < players.Count; i++)
            {
                ConsoleHelper.CentraliseCursor(lengthForCentralizing);
                this.consoleWriter.WriteLine(PlayersTemplateString, i + 1, players[i].Name, players[i].Moves);
            }
        }

        public void RenderGameErrorMessage(string message)
        {
            ConsoleHelper.DisplayInputErrorMessage(message, this.consoleWriter);
        }

        private void PrintMatrix(IGameField field)
        {
            int rows = field.Rows;
            int columns = field.Columns;

            for (int row = 0; row < rows; row++)
            {
                // Prints rows index     
                this.consoleWriter.Write(FieldLeftBorderSymbol, row + 1);

                for (int column = 0; column < columns; column++)
                {
                    if (ObjectValidator.IsGameObjectNull(field[row, column]))
                    {
                        throw new ArgumentNullException(FieldCellNullErrorMessage);
                    }

                    string symbol = field[row, column].Symbol;
                    BalloonsColors symbolColor = field[row, column].Color;

                    ConsoleHelper.ChangeForegroundColorDependingOnSymbol(symbolColor);
                    this.consoleWriter.Write(field[row, column].Symbol + " ");
                }

                Console.ForegroundColor = ConsoleColor.Gray;
                this.consoleWriter.Write(FieldRigthBorderSymbol);
                Console.WriteLine();
            }
        }

        private void PrintBorder(int columns)
        {
            this.consoleWriter.Write(Indent);
            this.consoleWriter.WriteLine(new string(TopAndBottomBorderSymbol, columns * 2));
        }
    }
}
