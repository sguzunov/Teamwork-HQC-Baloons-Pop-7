﻿namespace Balloons
{
    using Balloons.Cell;
    using Balloons.Commands;
    using Balloons.Common;
    using Balloons.Common.ConsoleContext;
    using Balloons.FieldFactory;
    using Balloons.FieldFactory.Field;
    using Balloons.GameEngine;
    using Balloons.InputHandler;
    using Balloons.Memory;
    using Balloons.ReorderStrategy;
    using Balloons.UI;

    /// <summary>
    /// This class provides an easy interface for game dependency initialization.
    /// </summary>
    public static class GameEntry
    {
        /// <summary>
        /// This method instantiate all dependencies for the game.
        /// </summary>
        public static void StartGame()
        {
            // Console context dependancies
            IConsoleWriter consoleWriter = new ConsoleWriter();
            IConsoleReader consoleReader = new ConsoleReader();

            // Instantiate game dependancies
            IRenderer renderer = new ConsoleRenderer(consoleWriter);
            IInputHandler inputHandler = new ConsoleInputHandler(consoleWriter, consoleReader);
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

        /// <summary>
        /// Depending the game mode value provides object representing the class having the needed logic.
        /// </summary>
        /// <param name="gameMode">The needed mode taken from the user.</param>
        /// <returns>Concrete instance of the mode.</returns>
        private static ReorderBalloonsStrategy GetReorderStrategy(GameMode gameMode)
        {
            ReorderBalloonsStrategy strategy;
            if (gameMode == GameMode.Fly)
            {
                strategy = new ReorderBalloonsStrategyFly();
            }
            else
            {
                strategy = new ReorderBalloonsStrategyDefault();
            }

            return strategy;
        }
    }
}
