namespace Balloons
{
    using Balloons.GameEngine;
    using Balloons.InputHandler;
    using Balloons.UI;

    public static class Facade
    {
        public static void StartGame()
        {
            IRenderer renderer = new ConsoleRenderer();
            IInputHandler inputHandler = new ConsoleInputHandler();
            IBalloonsEngine engine = new BalloonsGameEngine(renderer, inputHandler);

            engine.InitializeGame();
            engine.StartGame();
        }
    }
}
