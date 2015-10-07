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
            // TODO : Needs logic for GAME MODE

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

                Console.WriteLine(parsedCommand[0]);
                var command = this.commandManger.GetCommand(parsedCommand);

                command.Execute();

                //TODO : Logic for reordering goes here!!!
                this.renderer.RenderGameField(this.field);

                if (this.IsGameFinished(this.field))
                {
                    // Ask player for name and sets points
                    this.player.Name = "Pesho";
                    this.player.Points = 15;
                    ScoreBoard.Instance.AddPlayer(this.player);
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
