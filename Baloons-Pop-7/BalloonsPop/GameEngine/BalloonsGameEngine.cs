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
            this.commandManger = new CommandManager(this.renderer, this.field, activeRow = 0, activeCol = 0); // Not sure if good!!!
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
                // TODO : Logic for reordering goes here!!!
                this.renderer.RenderGameField(this.field);

                if (this.IsGameFinished())
                {
                    // Ask player for name and sets points
                    this.player.Name = "Pesho";
                    this.player.Points = 15;
                    ScoreBoard.Instance.AddPlayer(this.player);
                }
            }

            //var inputHandler = new ConsoleInputHandler();
            //string input;
            //string parsedInput;

            //while (true)
            //{
            //    Console.Write(GameMessages.CELL_INPUT_MESSAGE);
            //    input = inputHandler.ReadInput();
            //    parsedInput = inputHandler.ParseInput(input, field);
            //    Console.WriteLine("Input: " + input);
            //    Console.WriteLine("Parsed Input: " + parsedInput);

            //    int activeRow,
            //        activeCol;

            //    if (parsedInput.Split(' ').Length < 3)
            //    {
            //        activeRow = 0;
            //        activeCol = 0;
            //    }
            //    else
            //    {
            //        activeRow = int.Parse(parsedInput.Split(' ')[1]);
            //        activeCol = int.Parse(parsedInput.Split(' ')[2]);
            //    }

            //    // ICommand command = GetCommand(parsedInput);
            //    CommandContext context = new CommandContext(this.field, activeRow, activeCol);
            //    //  command.Execute(context);
            //    strategy.ReorderBalloons(this.field);

            //    this.renderer.RenderGameField(this.field);

            //}
        }

        // This method is comented because the logic for getting ICommand is changed and this leads to exception.
        // public ICommand GetCommand(string action)
        //{
        //string command = action.Split(' ')[0];
        //ICommand cmd = null;
        ////CommandContext ctx = null;

        //switch (command)
        //{
        //    case "exit":
        //        cmd = new ExitCommand();
        //        break;
        //    case "top":
        //        cmd = new ShowScoreboardCommand();
        //        break;
        //    case "undo":
        //        cmd = new UndoCommand();
        //        break;
        //    case "help":
        //        cmd = new HelpCommand();
        //        break;
        //    case "start":
        //        cmd = new StartCommand();
        //        break;
        //    case "restart":
        //        cmd = new StartCommand();
        //        break;

        //    case "pop":
        //        if (action.Split(' ')[1] == "invalid")
        //        {
        //            cmd = new InvalidCommand();
        //        }
        //        else
        //        {
        //            cmd = new PopBalloonsCommand();
        //        }
        //        break;

        //    case "":
        //        cmd = new InvalidPopCommand();
        //        break;
        //    default:
        //        cmd = new InvalidCommand();
        //        break;
        //}
        //return cmd;
        //}

        public bool IsGameFinished()
        {
            // TODO : Logic for finished game goes here!!!
            return false;
        }
    }
}
