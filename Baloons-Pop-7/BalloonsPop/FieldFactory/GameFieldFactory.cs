namespace Balloons.FieldFactory
{
    using System;

    using Balloons.Common;
    using Balloons.FieldFactory.Field;

    public class GameFieldFactory : IFieldFactory
    {
        private const int EasyGameFieldRows = 6;
        private const int EasyGameFieldColumns = 6;
        private const int HardGameFieldRows = 9;
        private const int HardGameFieldColumns = 9;
        private const string TypeErrorMessage = "The game difficulty does not exists!";

        public IGameField CreateGameField(GameDifficulty difficulty)
        {
            switch (difficulty)
            {
                case GameDifficulty.Easy:
                    {
                        IGameField field = new GameField(EasyGameFieldRows, EasyGameFieldColumns);
                        return field;
                    }

                case GameDifficulty.Hard:
                    {
                        IGameField field = new GameField(HardGameFieldRows, HardGameFieldColumns);
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
