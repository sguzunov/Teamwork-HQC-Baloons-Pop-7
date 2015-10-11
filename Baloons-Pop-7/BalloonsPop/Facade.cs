namespace Balloons
{
    using Balloons.Cell;
    using Balloons.Commands;
    using Balloons.Common;
    using Balloons.FieldFactory;
    using Balloons.FieldFactory.Field;
    using Balloons.GameEngine;
    using Balloons.InputHandler;
    using Balloons.Memory;
    using Balloons.ReorderStrategy;
    using Balloons.UI;

    public static class Facade
    {
        public static void StartGame()
        {
            // Console context dependancies
            IConsoleWriter consoleWriter = new ConsoleWriter();

            // Instantiate game dependancies
            IRenderer renderer = new ConsoleRenderer(consoleWriter);
            IInputHandler inputHandler = new ConsoleInputHandler(consoleWriter);
            IFieldFactory fieldFactory = new GameFieldFactory();
            IFieldMemoryManager fieldMemoryManager = new FieldMemoryManager();
            IBalloonsFactory balloonsFactory = new BalloonsFactory();
            IFiller matrixFiller = new Filler(balloonsFactory);
            ICommandManager commandManager = new CommandManager();

            // Printing initial screen goes here.
            renderer.RenderGameMessage(GameMessages.InitialGameMessage);
            renderer.RenderCommands(GameMessages.CommandsMessages);

            // Getting mode and difficulty goes here.
            GameMode gameMode = inputHandler.GetGameMode();
            GameDifficulty gameDifficulty = inputHandler.GetGameDifficulty();

            var reorderStrategy = GetReorderStrategy(gameMode);

            // Fluent interface implementation
            IBalloonsEngine engine = new BalloonsGameEngine()
                .Renderer(renderer)
                .Input(inputHandler)
                .FieldFactory(fieldFactory)
                .FieldMemoryManager(fieldMemoryManager)
                .BalloonsFactory(balloonsFactory)
                .CommandManager(commandManager)
                .ReorderBalloonsStrategy(reorderStrategy)
                .GameFieldFiller(matrixFiller);

            engine.InitializeGame(gameDifficulty);
            engine.StartGame();
        }

        private static ReorderBalloonsStrategy GetReorderStrategy(GameMode gameMode)
        {
            ReorderBalloonsStrategy strategy;
            if (gameMode == GameMode.Fly)
            {
                strategy = new ReorderBallonsStrategyFly();
            }
            else
            {
                strategy = new ReorderBallonsStrategyDefault();
            }

            return strategy;
        }
    }
}
