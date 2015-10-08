namespace Balloons.FieldFactory.Field
{
    using System;

    using Balloons.Cell;
    using Balloons.Memory;

    public class GameField : IGameField, IField, IMemorable
    {
        private const string RowPositionErrorMessage = "Invalid row position!";
        private const string ColumnPositionErrorMessage = "Invalid column position!";

        private int rows;
        private int columns;
        private Balloon[,] fieldMatrix;

        /// <remarks>The number of rows must be less than 10 and the number of columns must not be bigger than 10 because UI breaks.</remarks>
        public GameField(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
            this.fieldMatrix = new Balloon[this.Rows, this.Columns];
        }

        public IFiller Filler { get; set; }

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
                    throw new IndexOutOfRangeException(RowPositionErrorMessage);
                }

                if (!this.IsValidColumn(column))
                {
                    throw new IndexOutOfRangeException(ColumnPositionErrorMessage);
                }

                return this.fieldMatrix[row, column];
            }

            set
            {
                if (!this.IsValidRow(row))
                {
                    throw new IndexOutOfRangeException(RowPositionErrorMessage);
                }

                if (!this.IsValidColumn(column))
                {
                    throw new IndexOutOfRangeException(ColumnPositionErrorMessage);
                }

                this.fieldMatrix[row, column] = value;
            }
        }

        public void Fill()
        {
            this.Filler.Fill(this.fieldMatrix);
        }

        public FieldMemory SaveField()
        {
            var fieldCopy = (Balloon[,])this.fieldMatrix.Clone();
            var memento = new FieldMemory(fieldCopy);

            return memento;
        }

        public void RestoreField(FieldMemory memento)
        {
            this.fieldMatrix = memento.GetMemento();
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
