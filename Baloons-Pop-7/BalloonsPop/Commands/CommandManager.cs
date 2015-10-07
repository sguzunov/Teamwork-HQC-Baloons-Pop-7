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
        private IRenderer renderer;
        private IGameField field;
        private int activeRow;
        private int activeCol;


        public CommandManager(IRenderer renderer, IGameField field, int activeRow, int activeCol)
        {
            this.renderer = renderer;
            this.field = field;
            this.activeRow = activeRow;
            this.activeCol = activeCol;

            commands.Add("top", new TopScoresCommand(this.renderer));
            commands.Add("save", new SaveCommand(this.field));
            commands.Add("restore", new RestoreCommand(this.field));
            commands.Add("exit", new ExitCommand(this.renderer));
            commands.Add("help", new HelpCommand(this.renderer));
            commands.Add("pop", new PopBalloonsCommand(this.renderer, this.field, this.activeRow, this.activeCol));
            Console.WriteLine("into the const {0}", this.activeRow);
        }

        public ICommand GetCommand(IList<string> commandName)
        {
            bool hasCommand = this.CheckIfCommandExists(commandName);

            if (hasCommand)
            {
                
                if (commandName.Count > 2)
                {
                    this.activeRow = int.Parse(commandName[1]);
                    this.activeCol = int.Parse(commandName[2]);
                    commands.Remove("pop");
                    commands.Add("pop", new PopBalloonsCommand(this.renderer, this.field, this.activeRow, this.activeCol));
                }

                return this.commands[commandName[0]];
            }
            else
            {
                throw new InvalidOperationException("The game does now contain such a command!");
            }
        }

        private bool CheckIfCommandExists(IList<string> commandName)
        {
            return this.commands.Any(c => c.Value.Name == commandName[0]);
        }
    }
}
