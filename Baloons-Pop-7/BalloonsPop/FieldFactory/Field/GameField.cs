namespace Balloons.FieldFactory.Field
{
    using System;

    using Balloons.Cell;

    public class GameField : IGameField
    {
        private int rows;
        private int columns;
        private Balloon[,] field;

        /// <remarks>The number of rows must be less than 10 and the number of columns must not be bigger than 10 because UI breaks.</remarks>
        public GameField(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
            this.field = new Balloon[this.Rows, this.Columns];
        }

        public int Rows
        {
            get
            {
                return this.rows;
            }

            private set
            {
                if (this.IsValidDimension(value))
                {
                    throw new IndexOutOfRangeException("Rows count cannot be less than 2!");
                }

                this.rows = value;
            }
        }

        public int Columns
        {
            get
            {
                return this.columns;
            }

            private set
            {
                if (this.IsValidDimension(value))
                {
                    throw new IndexOutOfRangeException("Columns count cannot be less than 2!");
                }

                this.columns = value;
            }
        }

        public Balloon this[int row, int column]
        {
            get
            {
                if (!this.IsValidRow(row))
                {
                    throw new IndexOutOfRangeException("Invalid row position!");
                }

                if (!this.IsValidColumn(column))
                {
                    throw new IndexOutOfRangeException("Invalid column position!");
                }

                return this.field[row, column];
            }

            set
            {
                if (!this.IsValidRow(row))
                {
                    throw new IndexOutOfRangeException("Invalid row position!");
                }

                if (!this.IsValidColumn(column))
                {
                    throw new IndexOutOfRangeException("Invalid column position!");
                }

                this.field[row, column] = value;
            }
        }

        public void Fill()
        {
            int random;
            for (int row = 0; row < this.Rows; row++)
            {
                for (int column = 0; column < this.Columns; column++)
                {
                    random = RandomProvider.GetRandomNumber(1, 5);
                    
                    switch (random)
	                {
                        case 1: 
                            this.field[row, column] = new BalloonOne();
                            break;
                        case 2:
                            this.field[row, column] = new BalloonTwo();
                            break;
                        case 3:
                            this.field[row, column] = new BalloonThree();
                            break;
                        case 4:
                            this.field[row, column] = new BalloonFour();
                            break;
		                default:
                            this.field[row, column] = new BalloonFour();
                         break;
	                }
                    
                }
            }
        }

        private bool IsValidRow(int row)
        {
            return 0 <= row && row < this.Rows;
        }

        private bool IsValidColumn(int column)
        {
            return 0 <= column && column < this.Columns;
        }

        private bool IsValidDimension(int size)
        {
            return size < 2;
        }
    }
}
