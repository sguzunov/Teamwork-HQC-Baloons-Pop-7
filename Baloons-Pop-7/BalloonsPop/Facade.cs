namespace Balloons
{
    using Balloons.UI;
    using Balloons.InputHandler;
    using Balloons.GameEngine;
    using Balloons.FieldFactory;
    using Balloons.GameRules;

    public static class Facade
    {
        public static void StartGame()
        {
            IRenderer renderer = new ConsoleRenderer();
            IInputHandler inputHandler = new ConsoleInputHandler();
            IFieldFactory fieldFactory = new GameFieldFactory();

            IBalloonsEngine engine = new BalloonsGameEngine(renderer, inputHandler, fieldFactory);

            engine.InitializeGame();
            engine.StartGame();
        }
    }
}
