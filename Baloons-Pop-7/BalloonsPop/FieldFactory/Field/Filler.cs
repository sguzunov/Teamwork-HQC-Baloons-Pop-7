namespace Balloons.FieldFactory.Field
{
    using Balloons.Cell;

    public class Filler : IFiller
    {
        private readonly IBalloonsFactory balloonsFactory;

        public Filler(IBalloonsFactory balloonsFactory)
        {
            this.balloonsFactory = balloonsFactory;
        }

        public void Fill(Balloon[,] field)
        {
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
