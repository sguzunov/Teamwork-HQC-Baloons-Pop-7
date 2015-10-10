namespace Balloons.GameEngine
{
    using System;
    using System.Collections.Generic;

    using Balloons.Cell;
    using Balloons.Commands;
    using Balloons.Common;
    using Balloons.FieldFactory;
    using Balloons.FieldFactory.Field;
    using Balloons.GamePlayer;
    using Balloons.GameScore;
    using Balloons.InputHandler;
    using Balloons.Memory;
    using Balloons.UI;
    using Balloons.ReorderStrategy;

    public class BalloonsGameEngine : IBalloonsEngine
    {
        private readonly GameEngineContext engineContext = new GameEngineContext();
        private ReorderBalloonsStrategy strategy;
        private ICommandManager commandManger;
        private IGameField field;


        public BalloonsGameEngine Renderer(IRenderer renderer)
        {
            this.engineContext.Renderer = renderer;
            return this;
        }

        public BalloonsGameEngine Input(IInputHandler inputHandler)
        {
            this.engineContext.Input = inputHandler;
            return this;
        }

        public BalloonsGameEngine FieldFactory(IFieldFactory fieldFactory)
        {
            this.engineContext.FieldFactory = fieldFactory;
            return this;
        }

        public BalloonsGameEngine Mode(GameMode gameMode)
        {
            this.engineContext.GameMode = gameMode;
            return this;
        }

        public BalloonsGameEngine GameDifficulty(GameDifficulty gameDifficulty)
        {
            this.engineContext.GameDifficulty = gameDifficulty;
            return this;
        }

        public BalloonsGameEngine Player(IPlayer player)
        {
            this.engineContext.Player = player;
            return this;
        }

        public BalloonsGameEngine FieldMemoryManager(IFieldMemoryManager fieldMemoryManager)
        {
            this.engineContext.FieldMemoryManager = fieldMemoryManager;
            return this;
        }

        public BalloonsGameEngine BalloonsFactory(IBalloonsFactory balloonsFactory)
        {
            this.engineContext.BalloonsFactory = balloonsFactory;
            return this;
        }

        public void InitializeGame()
        {
            if (this.engineContext.GameMode == GameMode.Fly)
            {
                this.strategy = new ReorderBallonsStrategyFly();
            }
            else
            {
                this.strategy = new ReorderBallonsStrategyDefault();
            }

            this.field = this.engineContext.FieldFactory.CreateGameField(this.engineContext.GameDifficulty);

            // Needs refactoring
            var filler = new Filler(this.engineContext.BalloonsFactory);
            this.field.Filler = filler;
            this.field.Fill();
            this.commandManger = new CommandManager();
        }

        public void StartGame()
        {
            var moves = 0;

            while (true)
            {
                this.engineContext.Renderer.RenderGameField(this.field);

                var commandInput = this.engineContext.Input.ReadInputCommand();



                try
                {

                    // Get command from manager and tries to execute
                    var command = this.commandManger.ProcessCommand(
                        commandInput,
                        this.engineContext.Renderer,
                        this.field,
                        this.engineContext.FieldMemoryManager,
                        this.engineContext.BalloonsFactory);

                    command.Execute();
                    if (command.Name == "pop")
                    {
                        moves++;
                    }

                    ReorderBallons(this.field);

                    if (this.IsGameFinished(this.field))
                    {
                        var points = ((this.field.Rows * this.field.Columns) - moves) * 100;
                        this.engineContext.Renderer.RenderGameField(this.field);
                        Console.Write("Please enter your name:");
                        this.engineContext.Player.Name = Console.ReadLine();
                        this.engineContext.Player.Points = points;
                        ScoreBoard.Instance.AddPlayer(this.engineContext.Player);
                        ICommand showScore = new TopScoresCommand(this.engineContext.Renderer);
                        showScore.Execute();

                        AnotherRound playAnotherRound = this.engineContext.Input.GetPlayAgainResponse();

                        if (playAnotherRound == AnotherRound.Yes)
                        {
                            Facade.StartGame();
                        }
                        else
                        {
                            ICommand exit = new ExitCommand(this.engineContext.Renderer);
                            exit.Execute();
                        }
                    }
                }
                catch (Exception exception)
                {
                    this.engineContext.Renderer.RenderGameErrorMessage(exception.Message);
                }
            }
        }

        public bool IsGameFinished(IGameField field)
        {
            int rows = field.Rows;
            int columns = field.Columns;
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if (field[row, column].Symbol != GameConstants.PopedBalloonSymbol)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void ReorderBallons(IGameField field)
        {
            strategy.ReorderBalloons(field);
        }
    }
}
