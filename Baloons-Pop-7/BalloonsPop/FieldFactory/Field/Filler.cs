﻿namespace Balloons.FieldFactory.Field
{
    using System;

    using Balloons.Cell;

    public class Filler : IFiller
    {
        private const string FieldNullErrorMessage = "Filler cannot take null field";

        private readonly IBalloonsFactory balloonsFactory;

        public Filler(IBalloonsFactory balloonsFactory)
        {
            this.balloonsFactory = balloonsFactory;
        }

        public void Fill(Balloon[,] field)
        {
            if (field == null)
            {
                throw new ArgumentNullException(FieldNullErrorMessage);
            }

            int rows = field.GetLength(0);
            int columns = field.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    string randomSymbol = RandomProvider.GetRandomNumber(1, 5).ToString();

                    field[row, column] = this.balloonsFactory.GetBalloon(randomSymbol);
                }
            }
        }
    }
}
