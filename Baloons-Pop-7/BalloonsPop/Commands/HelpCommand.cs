using Balloons.UI;

namespace Balloons.Commands
{
    using System;

    public class HelpCommand : ICommand
    {
        private readonly IRenderer renderer;

        public HelpCommand(IRenderer renderer)
        {
            this.renderer = renderer;
            this.Name = "help";
        }

        public string Name { get; private set; }

        public void Execute()
        {
            // TODO : Check if it is better RenderCommand to get command from method params
            this.renderer.RenderCommands();
        }
    }
}
