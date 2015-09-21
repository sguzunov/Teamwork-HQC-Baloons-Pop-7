namespace Baloons
{
    using System;

    using Common;
    using Gamefield;
    using InputHandler;

    public class StartCommand
    {
        public static void Start()
        {
            Console.WriteLine(GameMessages.INITIAL_GAME_MESSAGE);

            GameField.gameField = GameField.InitialGameField(GameConstants.WIDTH, GameConstants.HEIGHT);
            GameField.Draw(GameField.gameField, GameConstants.WIDTH, GameConstants.HEIGHT);

            InputHanlder.GameLogic(InputHanlder.userInput);
        }
    }
}
