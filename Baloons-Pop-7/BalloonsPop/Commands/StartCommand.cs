namespace Balloons.Commands
{
    using System;

    using Balloons.Common;
    using Balloons.GameField;
    using Balloons.InputHandler;
    using Balloons.ConsoleUI;
    using Balloons.Common;
    using Balloons.GameFieldFactories;

    public class StartCommand
    {
        public static void Start()
        {
            Console.WriteLine();

            // just testing
            var difficulty = GameType.Easy;

            IGameField field = GameFieldFactory.CreateGameField(difficulty);
            Console.WriteLine(field[0,0]);

        }
    }
}
