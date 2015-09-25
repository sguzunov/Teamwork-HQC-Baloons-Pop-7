﻿namespace Balloons.Commands
{
    using System;

    using Balloons.Common;
    using Balloons.GameField;
    using Balloons.InputHandler;
    using Balloons.ConsoleUI;

    public class StartCommand
    {
        public static void Start()
        {
            Console.WriteLine();
            Console.WriteLine(GameMessages.INITIAL_GAME_MESSAGE);

            GameField.gameField = GameField.InitialGameField(GameConstants.WIDTH_OF_FIELD, GameConstants.HEIGHT_OF_FIELD);
            FieldDrawer.Draw(GameField.gameField, GameConstants.WIDTH_OF_FIELD, GameConstants.HEIGHT_OF_FIELD);

            InputHanlder.GameLogic(InputHanlder.userInput);
        }
    }
}
