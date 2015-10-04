namespace Balloons.FieldFactory.Field
{
    using Balloons.Cell;

    public interface IGameField
    {
        int Rows { get; }

        int Columns { get; }

        Balloon this[int row, int column] { get; set; }

        void Fill();
    }
}
