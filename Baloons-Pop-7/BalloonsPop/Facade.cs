namespace Balloons
{
    using Balloons.UI;
    using Balloons.InputHandler;
    using Balloons.GameEngine;
    using Balloons.FieldFactory;
    using Balloons.Common;
    using Balloons.GamePlayer;

    public static class Facade
    {
        public static void StartGame()
        {
            IRenderer renderer = new ConsoleRenderer();
            IInputHandler inputHandler = new ConsoleInputHandler();
            IFieldFactory fieldFactory = new GameFieldFactory();
            IPlayer player = new Player();

            // Printing initial screen goes here.
            renderer.RenderMenu();
            renderer.RenderCommands(GameMessages.CommandsMessages);

            // Getting mode and difficulty goes here.
            GameMode gameMode = inputHandler.GetGameMode();
            GameDifficulty gameDifficulty = inputHandler.GetGameDifficulty();

            IBalloonsEngine engine = new BalloonsGameEngine(renderer, inputHandler, fieldFactory, gameMode, gameDifficulty, player);
            engine.InitializeGame();
            engine.StartGame();
        }
    }
}
