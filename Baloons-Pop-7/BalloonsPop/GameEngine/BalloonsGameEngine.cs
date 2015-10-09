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
        private int activeRow;
        private int activeCol;

        //private IRenderer renderer;
        //private IInputHandler inputHandler;
        //private IFieldFactory fieldFactory;
        //private GameMode gameMode;
        //private GameDifficulty gameDifficulty;

        //private IFieldMemoryManager fieldMemoryManager;
        //private IPlayer player;


        //public BalloonsGameEngine(IRenderer renderer, IInputHandler inputHandler, IFieldFactory fieldFactory,
        //    GameMode mode, GameDifficulty difficulty, IFieldMemoryManager fieldMemorizerManager,
        //    IPlayer player)
        //{
        //    this.renderer = renderer;
        //    this.inputHandler = inputHandler;
        //    this.fieldFactory = fieldFactory;
        //    this.gameMode = mode;
        //    this.gameDifficulty = difficulty;
        //    this.player = player;
        //    this.fieldMemoryManager = fieldMemorizerManager;
        //}

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
            var filler = new Filler(new BalloonsFactory());
            this.field.Filler = filler;
            this.field.Fill();

            this.commandManger = new CommandManager(this.engineContext.Renderer, this.field,
                this.engineContext.FieldMemoryManager, this.engineContext.BalloonsFactory,
                this.activeRow, this.activeCol);
        }

        public void StartGame()
        {
            var moves = 0;

            while (true)
            {
                this.engineContext.Renderer.RenderGameField(this.field);

                IList<string> inputCommand = this.engineContext.Input.ReadInputCommand();
                IList<string> parsedCommand = this.engineContext.Input.ParseInput(inputCommand, this.field);
                try
                {
                    var command = this.commandManger.GetCommand(parsedCommand);

                    command.Execute();
                    if (command.Name == "pop")
                    {
                        moves++;
                    }

                    ReorderBallons();

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
                catch (InvalidOperationException)
                {
                    this.engineContext.Renderer.RenderGameField(this.field);
                    Console.WriteLine("Invalid command entered");
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

        private void ReorderBallons()
        {
            strategy.ReorderBalloons(this.field);
        }
    }
}
