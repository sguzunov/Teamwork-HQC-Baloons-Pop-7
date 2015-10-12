namespace Balloons.GamePlayer
{
    public class Player : IPlayer
    {
        public Player()
        {
        }

        public Player(string name, int moves)
        {
            this.Name = name;
            this.Moves = moves;
        }

        public string Name { get; set; }

        public int Moves { get; set; }
    }
}
