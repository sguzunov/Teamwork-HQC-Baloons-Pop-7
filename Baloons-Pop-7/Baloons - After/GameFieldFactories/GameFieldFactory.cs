namespace Balloons.GameFieldFactories
{
    using System;

    using Balloons.Common;
    using Balloons.GameField;

    public class GameFieldFactory
    {
        private const string TypeErrorMessage = "The game type does not exists!";

        public IGameField CreateGameField(GameType type)
        {
            switch (type)
            {
                case GameType.Easy:
                    {
                        IGameField field = new GameField(GameConstants.EasyGameFieldRows, GameConstants.EasyGameFieldColumns);
                        return field;
                    }

                case GameType.Hard:
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
