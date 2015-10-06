
namespace Balloons.FieldFactory.Field
{
    using System;

    using Balloons.Cell;

    public class Fill : IFill
    {
        public void Fills(int Rows, int Columns, Balloon[,] field)
        {
            int random;
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    random = RandomProvider.GetRandomNumber(1, 5);

                    switch (random)
                    {
                        case 1:
                            field[row, column] = new BalloonOne();
                            break;
                        case 2:
                            field[row, column] = new BalloonTwo();
                            break;
                        case 3:
                            field[row, column] = new BalloonThree();
                            break;
                        case 4:
                            field[row, column] = new BalloonFour();
                            break;
                        default:
                            field[row, column] = new BalloonFour();
                            break;
                    }

                }
            }
        }
    }
}
