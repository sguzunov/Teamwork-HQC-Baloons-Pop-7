namespace Balloons.Cell
{
    public interface IBalloonsFactory
    {
        Balloon GetBalloon(string symbol);
    }
}
