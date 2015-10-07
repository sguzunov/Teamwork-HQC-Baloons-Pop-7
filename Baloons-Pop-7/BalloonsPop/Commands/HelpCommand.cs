namespace Balloons.Commands
{
    using Balloons.Common;
    using Balloons.UI;

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
            this.renderer.RenderCommands(GameMessages.CommandsMessages);
        }
    }
}
