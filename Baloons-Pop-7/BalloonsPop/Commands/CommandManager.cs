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
        public ICommand ProcessCommand(
            string commandString,
            IRenderer renderer,
            IGameField field,
            IFieldMemoryManager fieldMemoryManager,
            IBalloonsFactory balloonsFactory)
        {
            var commandParts = this.SplitCommandString(commandString);
            string commandName = commandParts[0];
            int rowPosition = 0;
            int colPosition = 0;

            if (commandParts.Length == 3)
            {
                rowPosition = commandParts[1] != null ? int.Parse(commandParts[1]) - 1 : 0;
                colPosition = commandParts[2] != null ? int.Parse(commandParts[2]) - 1 : 0;
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
