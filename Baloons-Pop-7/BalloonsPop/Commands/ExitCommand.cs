namespace Balloons.Commands
{
    using System;

    using Balloons.UI;

    public class ExitCommand : ICommand
    {
        private readonly IRenderer renderer;

        public ExitCommand(IRenderer renderer)
        {
            this.renderer = renderer;
            this.Name = "exit";
        }

        public string Name { get; private set; }

        public void Execute()
        {
            // TODO : Logic for shutting down cmd.
        }
    }
}
