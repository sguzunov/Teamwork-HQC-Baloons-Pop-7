namespace Balloons.Cell
{
    using Balloons.Common;

    public class BalloonTwo : Balloon
    {
        public BalloonTwo()
        {
            base.Symbol = "2";
            base.Color = BalloonsColors.White;
            base.Status = true;
        }
    }
}
