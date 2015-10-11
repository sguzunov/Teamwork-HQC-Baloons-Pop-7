namespace Balloons.GameEngine
{
    using Balloons.Cell;
    using Balloons.Commands;
    using Balloons.FieldFactory;
    using Balloons.FieldFactory.Field;
    using Balloons.InputHandler;
    using Balloons.Memory;
    using Balloons.ReorderStrategy;
    using Balloons.UI;

    public class GameEngineContext
    {
        public IRenderer Renderer { get; set; }

        public IInputHandler Input { get; set; }

        public IFieldFactory FieldFactory { get; set; }

        public IFieldMemoryManager FieldMemoryManager { get; set; }

        public IBalloonsFactory BalloonsFactory { get; set; }

        public ICommandManager CommandManager { get; set; }

        public IFiller GameFieldFiller { get; set; }

        public ReorderBalloonsStrategy ReorderBalloonsStrategy { get; set; }
    }
}
