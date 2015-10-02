namespace Balloons.FieldFactory.Field
{
    public interface IGameField
    {
        int Rows { get; }

        int Columns { get; }

        string this[int row, int column] { get; set; }

        void Fill();
    }
}
