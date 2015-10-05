namespace Balloons.Cell
{
    using Balloons.Common;

    public abstract class Balloon
    {
        public string Symbol { get; protected set; }

        public BalloonsColors Color { get; protected set; }
    }
}
