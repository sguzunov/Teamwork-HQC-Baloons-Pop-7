namespace Balloons.Cell
{
    using Balloons.Common;

    public abstract class Balloon
    {
        public string Symbol { get; set; }

        public bool Status { get; set; }

        public BalloonsColors Color { get; set; }

        public string Show()
        {
            return this.Symbol;
        }
    }
}
