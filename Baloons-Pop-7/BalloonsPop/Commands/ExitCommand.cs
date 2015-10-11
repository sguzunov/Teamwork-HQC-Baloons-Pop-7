namespace Balloons.Commands
{
    using System;

    using Balloons.Common;
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
            this.renderer.RenderGameMessage(GameMessages.EndGameMessage);
            Environment.Exit(0);
        }
    }
}
