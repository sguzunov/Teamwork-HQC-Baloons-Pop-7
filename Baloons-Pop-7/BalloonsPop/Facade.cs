namespace Balloons
{
    using Balloons.Common;
    using Balloons.FieldFactory;
    using Balloons.GameEngine;
    using Balloons.GamePlayer;
    using Balloons.InputHandler;
    using Balloons.Memory;
    using Balloons.UI;

    public static class Facade
    {
        public static void StartGame()
        {
            IRenderer renderer = new ConsoleRenderer();
            IInputHandler inputHandler = new ConsoleInputHandler();
            IFieldFactory fieldFactory = new GameFieldFactory();
            IPlayer player = new Player();
            IFieldMemoryManager fieldMemorizerManager = new FieldMemoryManager();

            // Printing initial screen goes here.
            renderer.RenderMenu();
            renderer.RenderCommands(GameMessages.CommandsMessages);

            // Getting mode and difficulty goes here.
            GameMode gameMode = inputHandler.GetGameMode();
            GameDifficulty gameDifficulty = inputHandler.GetGameDifficulty();

            IBalloonsEngine engine = new BalloonsGameEngine(renderer, inputHandler, fieldFactory, gameMode, gameDifficulty, fieldMemorizerManager, player);
            engine.InitializeGame();
            engine.StartGame();
        }
    }
}
