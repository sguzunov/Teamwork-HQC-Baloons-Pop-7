namespace Balloons.FieldFactory.Field
{
    public interface IGameField : IField, IMemorable
    {
        IFiller Filler { get; set; }
    }
}
