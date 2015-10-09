namespace Balloons.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Balloons.Cell;
    using Balloons.FieldFactory.Field;
    using Balloons.Memory;
    using Balloons.UI;

    public class CommandManager : ICommandManager
    {
        private const int InvalidRowAndColumnPosition = -1;

        public ICommand ProcessCommand(
            string commandString,
            IRenderer renderer,
            IGameField field,
            IFieldMemoryManager fieldMemoryManager,
            IBalloonsFactory balloonsFactory)
        {
            var commandParts = this.SplitCommandString(commandString);
            string commandName = commandParts[0];
            int rowPosition = -1;
            int colPosition = -1;

            bool rowAndColumnPopulated = !(string.IsNullOrWhiteSpace(commandParts[1]) && string.IsNullOrWhiteSpace(commandParts[2]));
            bool rowAsInteger = int.TryParse(commandParts[1], out rowPosition);
            bool columnAsInteger = int.TryParse(commandParts[2], out colPosition);

            if (commandParts.Length == 3)
            {
                if (rowAndColumnPopulated)
                {
                    rowPosition--;
                    colPosition--;
                }
                else
                {
                    rowPosition = InvalidRowAndColumnPosition;
                    colPosition = InvalidRowAndColumnPosition;
                }
            }

            switch (commandName)
            {
                case "pop":
                    {
                        return new PopBalloonsCommand(balloonsFactory, field, rowPosition, colPosition);
                    }

                case "top":
                    {
                        return new TopScoresCommand(renderer);
                    }

                case "save":
                    {
                        return new SaveCommand(fieldMemoryManager, field);
                    }

                case "restore":
                    {
                        return new RestoreCommand(fieldMemoryManager, field);
                    }

                case "help":
                    {
                        return new HelpCommand(renderer);
                    }

                case "exit":
                    {
                        return new ExitCommand(renderer);
                    }

                default:
                    {
                        throw new InvalidOperationException("Invalid command request!");
                    }
            }
        }

        private string[] SplitCommandString(string commandString)
        {
            var commandParts = commandString.Split(new char[] { ' ' });
            return commandParts;
        }
    }
}
