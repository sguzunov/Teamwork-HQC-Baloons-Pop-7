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

            this.renderer.RenderGameField(this.field);

            this.commandManger = new CommandManager(this.renderer, this.field, this.activeRow, this.activeCol);
        }

        public void StartGame()
        {
            while (true)
            {
                IList<string> inputCommand = this.inputHandler.ReadInputCommand();
                IList<string> parsedCommand = this.inputHandler.ParseInput(inputCommand, this.field);
                try
                {
                    var command = this.commandManger.GetCommand(parsedCommand);

                    command.Execute();
                    ReorderBallons();
                    this.renderer.RenderGameField(this.field);

                    if (this.IsGameFinished(this.field))
                    {
                        Console.Write("Please enter your name:");
                        this.player.Name = Console.ReadLine();
                        this.player.Points = 15;
                        ScoreBoard.Instance.AddPlayer(this.player);
                        ICommand showScore = new TopScoresCommand(this.renderer);
                        showScore.Execute();
                        Console.Write("Do you want to play again? (type yes/no)");
                        string input = Console.ReadLine().ToLower();

                        switch (input)
                        {
                            case "yes":
                                Facade.StartGame();
                                break;
                            case "no":
                                Environment.Exit(5);
                                break;
                            default: Console.Write("Invalid Input. Please type yes or no: ");
                                input = Console.ReadLine();
                                break;
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


        public bool IsGameFinished(IGameField field)
        {
            bool allPoped = false;
            int count = 0;

            for (int i = 0; i < field.Rows; i++)
            {
                for (int j = 0; j < field.Columns; j++)
                {
                    if (field[i, j].Symbol == ".")
                    {
                        count++;
                    }
                }
            }

            if (count == field.Columns * field.Rows)
            {
                allPoped = true;
            }

            return allPoped;
        }
    }
}
