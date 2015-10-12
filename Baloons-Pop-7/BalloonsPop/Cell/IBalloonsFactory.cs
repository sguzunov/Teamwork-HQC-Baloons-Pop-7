namespace Balloons.Cell
{
    public interface IBalloonsFactory
    {
        /// <summary>
        /// Interface for Balloon objects 
        /// </summary>
        Balloon GetBalloon(string symbol);
    }
}
