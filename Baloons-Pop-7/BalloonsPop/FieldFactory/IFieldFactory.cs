namespace Balloons.FieldFactory
{
    using Balloons.Common;
    using Balloons.FieldFactory.Field;

    public interface IFieldFactory
    {
        IGameField CreateGameField(GameDifficulty difficulty);
    }
}
