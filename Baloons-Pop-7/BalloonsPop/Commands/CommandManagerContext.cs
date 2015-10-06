namespace Balloons.Commands
{
    using Balloons.FieldFactory.Field;
    using Balloons.UI;

    public class CommandManagerContext
    {
        public IRenderer Renderer { get; set; }

        public IGameField Field { get; set; }
    }
}
