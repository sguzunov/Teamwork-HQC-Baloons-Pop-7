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


        public void ReorderBallons()
        {
            strategy.ReorderBalloons(this.field);
        }

        public BalloonsGameEngine(IRenderer renderer, IInputHandler inputHandler, IFieldFactory fieldFactory)
        {
            this.renderer = renderer;
            this.inputHandler = inputHandler;
            this.fieldFactory = fieldFactory;
            this.strategy = strategy;
        }

        public void InitializeGame()
        {
            // TODO : When have restart command ask pool.

            this.renderer.RenderMenu();

            this.gameMode = this.inputHandler.GetGameMode();
            this.gameDifficulty = this.inputHandler.GetGameDifficulty();

            // Three contexts following different strategies
            if (this.gameMode == GameMode.Fly)
            {
                this.strategy = new ReorderBallonsStrategyFly();
            }
            else
            {
                this.strategy = new ReorderBallonsStrategyDefault();
            }

            this.field = this.fieldFactory.CreateGameField(this.gameDifficulty);
            this.field.Fill();

            this.renderer.RenderGameField(this.field);


        }

        public void StartGame()
        {

            var inputHandler = new ConsoleInputHandler();
            string input;
            string parsedInput;

            while (true)
            {
                Console.Write(GameMessages.CELL_INPUT_MESSAGE);
                input = inputHandler.ReadInput();
                parsedInput = inputHandler.ParseInput(input, field);
                Console.WriteLine("Input: " + input);
                Console.WriteLine("Parsed Input: " + parsedInput);

                int activeRow,
                    activeCol;

                if (parsedInput.Split(' ').Length < 3)
                {
                    activeRow = 0;
                    activeCol = 0;
                }
                else
                {
                    activeRow = int.Parse(parsedInput.Split(' ')[1]);
                    activeCol = int.Parse(parsedInput.Split(' ')[2]);
                }

                ICommand command = GetCommand(parsedInput);
                CommandContext context = new CommandContext(this.field, activeRow, activeCol);
                command.Execute(context);
                strategy.ReorderBalloons(this.field);

                this.renderer.RenderGameField(this.field);

            }
        }

        public ICommand GetCommand(string action)
        {
            string command = action.Split(' ')[0];
            ICommand cmd = null;
            //CommandContext ctx = null;

            switch (command)
            {
                case "exit":
                    cmd = new ExitCommand();
                    break;
                case "top":
                    cmd = new ShowScoreboardCommand();
                    break;
                case "undo":
                    cmd = new UndoCommand();
                    break;
                case "help":
                    cmd = new HelpCommand();
                    break;
                case "start":
                    cmd = new StartCommand();
                    break;
                case "restart":
                    cmd = new StartCommand();
                    break;

                case "pop":
                    if (action.Split(' ')[1] == "invalid")
                    {
                        cmd = new InvalidCommand();
                    }
                    else
                    {
                        cmd = new PopBalloonsCommand();
                    }
                    break;

                case "":
                    cmd = new InvalidPopCommand();
                    break;
                default:
                    cmd = new InvalidCommand();
                    break;
            }
            return cmd;
        }

        public void IsGameFinished()
        {
            throw new NotImplementedException();
        }
    }
}
