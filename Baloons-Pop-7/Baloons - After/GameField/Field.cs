namespace Balloons.GameField
{
    using System;

    public class Field : IGameField
    {
        private int rows;
        private int columns;
        private string[,] field;

        public Field(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
            this.field = new string[this.Rows, this.Columns];
        }

        public int Rows
        {
            get
            {
                return this.rows;
            }

            private set
            {
                if (this.isValidDimension(value))
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
                if (this.isValidDimension(value))
                {
                    throw new IndexOutOfRangeException("Columns count cannot be less than 2!");
                }

                this.columns = value;
            }
        }

        public string this[int row, int column]
        {
            get
            {
                if (this.isValidRow(row))
                {
                    throw new IndexOutOfRangeException("Invalid row position!");
                }

                if (this.isValidColumn(column))
                {
                    throw new IndexOutOfRangeException("Invalid column position!");
                }

                return this.field[row, column];
            }

            set
            {
                if (this.isValidRow(row))
                {
                    throw new IndexOutOfRangeException("Invalid row position!");
                }

                if (this.isValidColumn(column))
                {
                    throw new IndexOutOfRangeException("Invalid column position!");
                }

                this.field[row, column] = value;
            }
        }

        public void Fill()
        {
            for (int row = 0; row < this.Rows; row++)
            {
                for (int column = 0; column < this.Columns; column++)
                {
                    this.field[row, column] = RandomGenerator.GetRandomInt();
                }
            }
        }

        private bool isValidRow(int row)
        {
            return 0 < row && row < this.Rows - 1;
        }

        private bool isValidColumn(int column)
        {
            return 0 < column && column < this.Columns - 1;
        }

        private bool isValidDimension(int size)
        {
            return size < 2;
        }
    }
}
