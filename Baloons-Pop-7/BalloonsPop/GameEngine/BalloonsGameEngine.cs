using Balloons.Cell;
using Balloons.GamePlayer;
using Balloons.GameScore;

namespace Balloons.GameEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Balloons.UI;
    using Balloons.InputHandler;
    using Balloons.FieldFactory;
    using Balloons.Common;
    using Balloons.FieldFactory.Field;
    using Balloons.Commands;
    using Balloons.GameRules;

    public class BalloonsGameEngine : IBalloonsEngine
    {
        private IRenderer renderer;
        private IInputHandler inputHandler;
        private IFieldFactory fieldFactory;
        private IGameField field;
        private GameMode gameMode;
        private GameDifficulty gameDifficulty;
        private ReorderBalloonsStrategy strategy;
        private ICommandManager commandManger;
        private IPlayer player;
        private int activeRow;
        private int activeCol;


        public void ReorderBallons()
        {
            strategy.ReorderBalloons(this.field);
        }

        public BalloonsGameEngine(IRenderer renderer, IInputHandler inputHandler,
            IFieldFactory fieldFactory, GameMode mode, GameDifficulty difficulty,
            IPlayer player)
        {
            this.renderer = renderer;
            this.inputHandler = inputHandler;
            this.fieldFactory = fieldFactory;
            this.gameMode = mode;
            this.gameDifficulty = difficulty;
            this.player = player;
        }

        public void InitializeGame()
        {
            if (this.gameMode == GameMode.Fly)
            {
                this.strategy = new ReorderBallonsStrategyFly();
            }
            else
            {
                this.strategy = new ReorderBallonsStrategyDefault();
            }

            this.field = this.fieldFactory.CreateGameField(this.gameDifficulty);

            // Needs refactoring
            var filler = new Filler(new BalloonsFactory());
            this.field.Filler = filler;
            this.field.Fill();

            this.commandManger = new CommandManager(this.renderer, this.field, this.activeRow, this.activeCol);
        }

        public void StartGame()
        {
            var moves = 0;

            while (true)
            {
                this.renderer.RenderGameField(this.field);

                IList<string> inputCommand = this.inputHandler.ReadInputCommand();
                IList<string> parsedCommand = this.inputHandler.ParseInput(inputCommand, this.field);
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
                        var points = ((this.field.Rows * this.field.Columns) - moves)*100;
                        this.renderer.RenderGameField(this.field);
                        Console.Write("Please enter your name:");
                        this.player.Name = Console.ReadLine();
                        this.player.Points = points;
                        ScoreBoard.Instance.AddPlayer(this.player);
                        ICommand showScore = new TopScoresCommand(this.renderer);
                        showScore.Execute();

                        AnotherRound playAnotherRound = inputHandler.GetPlayAgainResponse();

                        if (playAnotherRound == AnotherRound.Yes)
                        {
                            Facade.StartGame();
                        }
                        else
	                    {
                            ICommand exit = new ExitCommand(this.renderer);
                            exit.Execute();
	                    }
                    }
                }
                catch (InvalidOperationException)
                {
                    this.renderer.RenderGameField(this.field);
                    Console.WriteLine("Invalid command entered");
                }
            }
        }

        // TODO: refractor this method using Linq
        public bool IsGameFinished(IGameField field)
        {
            int rows = field.Rows;
            int columns = field.Columns;
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if (field[row, column].Symbol != ".")
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
