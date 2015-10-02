namespace Balloons.GameFieldFactories
{
    using System;

    using Balloons.Common;
    using Balloons.GameField;

    public class GameFieldFactory
    {
        private const string TypeErrorMessage = "The game type does not exists!";

        public static IGameField CreateGameField(GameDifficulty type)
        {
            switch (type)
            {
                case GameDifficulty.Easy:
                    {
                        IGameField field = new GameField(GameConstants.EasyGameFieldRows, GameConstants.EasyGameFieldColumns);
                        return field;
                    }

                case GameDifficulty.Hard:
                    {
                        IGameField field = new GameField(GameConstants.HardGameFieldRows, GameConstants.HardGameFieldColumns);
                        return field;
                    }

                default:
                    {
                        throw new InvalidOperationException(TypeErrorMessage);
                    }
            }
        }
    }
}
