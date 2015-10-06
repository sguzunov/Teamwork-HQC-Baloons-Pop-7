namespace Balloons.Commands
{
    using System;

    using Balloons.Commands;
    using Balloons.FieldFactory.Field;
    using Balloons.UI;
    using System.Collections.Generic;
    using System.Linq;

    public class CommandManager : ICommandManager
    {
        private readonly IDictionary<string, ICommand> commands = new Dictionary<string, ICommand>();
        private readonly CommandManagerContext context = new CommandManagerContext();

        public CommandManager()
        {
            commands.Add("top", new TopScoresCommand(this.context.Renderer));
            commands.Add("save", new SaveCommand(this.context.Field));
            commands.Add("restore", new RestoreCommand(this.context.Field));
            commands.Add("exit", new ExitCommand(this.context.Renderer));
            commands.Add("help", new HelpCommand(this.context.Renderer));
        }

        public CommandManager Renderer(IRenderer renderer)
        {
            this.context.Renderer = renderer;
            return this;
        }

        public CommandManager Field(IGameField field)
        {
            this.context.Field = field;
            return this;
        }

        public ICommand GetCommand(string commandName)
        {
            bool hasCommand = this.CheckIfCommandExists(commandName);
            if (hasCommand)
            {
                return this.commands[commandName];
            }
            else
            {
                throw new InvalidOperationException("The game does now contain such a command!");
            }
        }

        private bool CheckIfCommandExists(string commandName)
        {
            return this.commands.Any(c => c.Value.Name == commandName);
        }
    }
}
