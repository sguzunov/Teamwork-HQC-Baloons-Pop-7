namespace Balloons.GameField
{
    using System;

    public class Field : IGameField
    {
        private int rows;
        private int columns;
        private string[,] field;

        /// <remarks>The number of rows must be less than 10 and the number of columns must not be bigger than 10 because the UI goes wrong.</remarks>
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

        public string this[int row, int column]
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
            for (int row = 0; row < this.Rows; row++)
            {
                for (int column = 0; column < this.Columns; column++)
                {
                    this.field[row, column] = RandomProvider.GetRandomNumber(1, 5).ToString();
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
