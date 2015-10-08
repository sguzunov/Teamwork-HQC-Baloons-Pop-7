namespace Balloons.FieldFactory.Field
{
    using Balloons.Cell;

    public interface IGameField : IField, IMemorable
    {
        IFiller Filler { get; set; }
    }
}
