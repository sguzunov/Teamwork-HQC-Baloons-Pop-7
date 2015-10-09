namespace Balloons.GameEngine
{
    using Balloons.Cell;
    using Balloons.Common;
    using Balloons.FieldFactory;
    using Balloons.GamePlayer;
    using Balloons.InputHandler;
    using Balloons.Memory;
    using Balloons.UI;

    public class GameEngineContext
    {
        public IRenderer Renderer { get; set; }

        public IInputHandler Input { get; set; }

        public IFieldFactory FieldFactory { get; set; }

        public GameMode GameMode { get; set; }

        public GameDifficulty GameDifficulty { get; set; }

        public IPlayer Player { get; set; }

        public IFieldMemoryManager FieldMemoryManager { get; set; }

        public IBalloonsFactory BalloonsFactory { get; set; }
    }
}
