namespace Balloons.Cell
{
    using Balloons.Common;

    public class BalloonPoped : Balloon
    {
        public BalloonPoped()
        {
            base.Symbol = ".";
            base.Color = BalloonsColors.Blue;
            base.Status = true;
        }
    }
}
