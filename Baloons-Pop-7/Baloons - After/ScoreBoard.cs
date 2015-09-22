namespace Balloons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Balloons.GamePlayer;

    public class ScoreBoard
    {
        private IList<IPlayer> players;

        public ScoreBoard()
        {
            this.players = new List<IPlayer>();
        }

        public IList<IPlayer> GetPlayers
        {
            get
            {
                return this.players;
            }
        }

        public void AddPlayer(IPlayer newPlayer)
        {
            if (newPlayer == null)
            {
                throw new ArgumentNullException("New player cannot be null.");
            }

            this.players.Add(newPlayer);

            this.players = this.SortPlayersByPoints(this.players);
        }

        private IList<IPlayer> SortPlayersByPoints(IList<IPlayer> players)
        {
            return this.players.OrderBy(p => p.Points).ToList();
        }
    }
}
