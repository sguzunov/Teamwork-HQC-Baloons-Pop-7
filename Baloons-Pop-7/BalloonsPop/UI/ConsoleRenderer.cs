namespace Balloons.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Balloons.Common;
    using Balloons.Common.ConsoleContext;
    using Balloons.FieldFactory.Field;
    using Balloons.GamePlayer;
    using Balloons.Helpers;

    /// <summary>
    /// Concrete game renderer which uses console for context.
    /// </summary>
    public class ConsoleRenderer : IRenderer
    {
        private const string FieldNullErrorMessage = "Field cannot be null!";
        private const string FieldCellNullErrorMessage = "Field cell cannot be null!";
        private const string PlayersNullErrorMessage = "Players list cannot be null!";
        private const string PlayersEmptyListErrorMessage = "Players count cannot be less than 1!";
        private const string CommandsCountErrorMessage = "Commands count cannot be less than one!";

        private const char TopAndBottomBorderSymbol = '-';
        private const string FieldLeftBorderSymbol = "{0} | ";
        private const string FieldRigthBorderSymbol = "| ";
        private const string Indent = "   ";
        private const string PlayersTemplateString = "{0}. {1} made {2} moves";

        private readonly IConsoleWriter consoleWriter;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleRenderer"/> class.
        /// </summary>
        public ConsoleRenderer()
            : this(new ConsoleWriter())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleRenderer"/> class.
        /// </summary>
        /// <param name="consoleWriter">Concrete console context.</param>
        public ConsoleRenderer(IConsoleWriter consoleWriter)
        {
            this.consoleWriter = consoleWriter;
        }

        /// <summary>
        /// Method which knows how to render on console game field matrix.
        /// </summary>
        /// <param name="field">Field to render.</param>
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

        /// <summary>
        /// Method which knows how to render all game messages on console.
        /// </summary>
        /// <param name="message">Concrete message to render.</param>
        public void RenderGameMessage(string message)
        {
            ConsoleHelper.CentraliseCursor(message.Length);
            this.consoleWriter.WriteLine(message);
        }

        /// <summary>
        /// Method which knows how to render all game commands on console.
        /// </summary>
        /// <param name="commands">An array containing string for rendering.</param>
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

        /// <summary>
        /// Method which knows how to render all players in the game on console.
        /// </summary>
        /// <param name="players">A list of players having info for rendering.</param>
        public void RenderGameTopPlayers(IList<IPlayer> players)
        {
            if (players == null)
            {
                throw new ArgumentNullException(PlayersNullErrorMessage);
            }

            if (players.Count < 1)
            {
                throw new ArgumentException(PlayersEmptyListErrorMessage);
            }

            int maxPlayerNameLength = players.Max(p => p.Name.Length);
            int lengthForCentralizing = PlayersTemplateString.Length + maxPlayerNameLength;
            for (int i = 0; i < players.Count; i++)
            {
                ConsoleHelper.CentraliseCursor(lengthForCentralizing);
                this.consoleWriter.WriteLine(PlayersTemplateString, i + 1, players[i].Name, players[i].Moves);
            }
        }

        /// <summary>
        /// Method which knows how to render all error messages on console on different way.
        /// </summary>
        /// <param name="message">A message for printing on console.</param>
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
