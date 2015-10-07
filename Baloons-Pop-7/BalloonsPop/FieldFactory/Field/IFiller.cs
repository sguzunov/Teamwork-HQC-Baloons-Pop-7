namespace Balloons.FieldFactory.Field
{
    using Balloons.Cell;

    public interface IFiller
    {
        void Fill(Balloon[,] field);
    }
}
