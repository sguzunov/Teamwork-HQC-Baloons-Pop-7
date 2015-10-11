namespace Balloons.GameEngine
{
    using System;

    using Balloons.Cell;
    using Balloons.Commands;
    using Balloons.Common;
    using Balloons.FieldFactory;
    using Balloons.FieldFactory.Field;
    using Balloons.GamePlayer;
    using Balloons.GameScore;
    using Balloons.InputHandler;
    using Balloons.Memory;
    using Balloons.ReorderStrategy;
    using Balloons.UI;

    public class BalloonsGameEngine : IBalloonsEngine
    {
        private readonly GameEngineContext engineContext = new GameEngineContext();

        private int gameRoundMoves;
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

        public BalloonsGameEngine CommandManager(ICommandManager commandManager)
        {
            this.engineContext.CommandManager = commandManager;
            return this;
        }

        public BalloonsGameEngine ReorderBalloonsStrategy(ReorderBalloonsStrategy reorderStrategy)
        {
            this.engineContext.ReorderBalloonsStrategy = reorderStrategy;
            return this;
        }

        public BalloonsGameEngine GameFieldFiller(IFiller matrixFiller)
        {
            this.engineContext.GameFieldFiller = matrixFiller;
            return this;
        }

        public void InitializeGame(GameDifficulty gameDifficulty)
        {
            this.PrepareNewGameRound(this.engineContext.FieldFactory, gameDifficulty);
        }

        public void StartGame()
        {
            while (true)
            {
                this.engineContext.Renderer.RenderGameField(this.field);
                var commandInput = this.engineContext.Input.ReadInputCommand();

                try
                {
                    // Get command from manager and tries to execute
                    var command = this.engineContext.CommandManager.ProcessCommand(
                        commandInput,
                        this.engineContext.Renderer,
                        this.field,
                        this.engineContext.FieldMemoryManager,
                        this.engineContext.BalloonsFactory);

                    command.Execute();
                    if (command.Name == "pop")
                    {
                        // Every pop command calculate a move.
                        this.gameRoundMoves++;
                        this.ReorderBallons(this.engineContext.ReorderBalloonsStrategy, this.field);
                    }

                    if (this.IsGameFinished(this.field))
                    {
                        var player = new Player();
                        player.Name = this.engineContext.Input.ReadPlayerInfo();
                        player.Moves = this.gameRoundMoves;
                        ScoreBoard.Instance.AddPlayer(player);

                        AnotherRound playAnotherRoundResponse = this.engineContext.Input.GetPlayAgainResponse();

                        if (playAnotherRoundResponse == AnotherRound.Yes)
                        {
                            var difficulty = this.engineContext.Input.GetGameDifficulty();
                            this.PrepareNewGameRound(this.engineContext.FieldFactory, difficulty);
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                catch (Exception exception)
                {
                    this.engineContext.Renderer.RenderGameErrorMessage(exception.Message);
                }
            }
        }

        private void PrepareNewGameRound(IFieldFactory fieldFactory, GameDifficulty gameDifficulty)
        {
            this.field = fieldFactory.CreateGameField(gameDifficulty);
            this.field.Filler = this.engineContext.GameFieldFiller;
            this.field.Fill();
        }

        private bool IsGameFinished(IGameField gameField)
        {
            int rows = gameField.Rows;
            int columns = gameField.Columns;
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if (gameField[row, column].Symbol != GameConstants.PopedBalloonSymbol)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void ReorderBallons(ReorderBalloonsStrategy reorderStrategy, IGameField gameField)
        {
            reorderStrategy.ReorderBalloons(gameField);
        }
    }
}
