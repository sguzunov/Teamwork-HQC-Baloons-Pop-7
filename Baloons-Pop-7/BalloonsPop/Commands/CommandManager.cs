namespace Balloons.Commands
{
    using System;

    using Balloons.FieldFactory.Field;
    using Balloons.UI;
    using System.Collections.Generic;
    using System.Linq;

    public class CommandManager : ICommandManager
    {
        private readonly IDictionary<string, ICommand> commands = new Dictionary<string, ICommand>();
        //private readonly CommandManagerContext context = new CommandManagerContext();
        private IRenderer renderer;
        private IGameField field;

        public CommandManager(IRenderer renderer, IGameField field)
        {
            this.renderer = renderer;
            this.field = field;

            commands.Add("top", new TopScoresCommand(this.renderer));
            commands.Add("save", new SaveCommand(this.field));
            commands.Add("restore", new RestoreCommand(this.field));
            commands.Add("exit", new ExitCommand(this.renderer));
            commands.Add("help", new HelpCommand(this.renderer));
        }

        //public ICommandManager Renderer(IRenderer renderer)
        //{
        //    this.context.Renderer = renderer;
        //    return this;
        //}

        //public ICommandManager Field(IGameField field)
        //{
        //    this.context.Field = field;
        //    return this;
        //}

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
