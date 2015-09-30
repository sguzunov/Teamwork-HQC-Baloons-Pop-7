namespace Balloons
{
    using Balloons.UI;
    using Balloons.InputHandler;
    using Balloons.GameEngine;

    public static class Facade
    {
        public static void StartGame()
        {
            IRenderer renderer = new ConsoleRenderer();
            IInputHandler inputHandler = new ConsoleInputHandler();
            IBalloonsEngine engine = new BalloonsGameEngine(renderer, inputHandler);

            engine.InitializeGame();
        }
    }
}
