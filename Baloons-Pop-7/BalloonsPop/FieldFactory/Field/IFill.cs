
namespace Balloons.FieldFactory.Field
{
    using System;

    using Balloons.Cell;

    public interface IFill
    {
        void Fills(int Rows, int Columns, Balloon[,] field);
    }
}
