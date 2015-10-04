namespace Balloons.Commands
{
    using Balloons.FieldFactory.Field;

    public class CommandContext
    {
        public CommandContext(IGameField gameField, int row, int col)
        {
            this.GameField = gameField;
            this.ActiveRow = row;
            this.ActiveCol = col;
        }

        public IGameField GameField { get; set; }

        public int ActiveCol { get; set; }

        public int ActiveRow { get; set; }
    }
}
