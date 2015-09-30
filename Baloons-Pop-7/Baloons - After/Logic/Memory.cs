namespace Balloons.Logic
{
    internal class Memory
    {
        public Memory(string[,] gameField, int moves,int filledCells)
        {
            this.GameField = gameField;
            this.Moves = moves;
            this.FilledCells = filledCells;
        }

        public string[,] GameField { get; set; }
        public int Moves { get; set; }
        public int FilledCells { get; set; }
    }
}
