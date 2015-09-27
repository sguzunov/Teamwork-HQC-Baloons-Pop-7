namespace Balloons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Balloons.GamePlayer;

    public class ScoreBoard
    {
        private const int MaxPossiblePlayers = 5;
        private const string PlayerNullErrorMessage = "New player cannot be null.";

        private static object syncLock = new object();
        private static ScoreBoard instance;
        private IList<IPlayer> listOfPlayers;

        private ScoreBoard()
        {
            this.listOfPlayers = new List<IPlayer>();
        }

        public static ScoreBoard Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                        {
                            instance = new ScoreBoard();
                        }
                    }
                }

                return instance;
            }
        }

        public IList<IPlayer> GetSortedPlayers
        {
            get
            {
                var sortedPlayers = this.SortPlayersByPoints(this.listOfPlayers);
                return sortedPlayers;
            }
        }

        public void AddPlayer(IPlayer newPlayer)
        {
            if (newPlayer == null)
            {
                throw new ArgumentNullException(PlayerNullErrorMessage);
            }

            if (this.listOfPlayers.Count < MaxPossiblePlayers)
            {
                this.listOfPlayers.Add(newPlayer);
            }
            else
            {
                this.listOfPlayers.Add(newPlayer);
                this.RemovePlayerWithLeastPoints(this.listOfPlayers);
            }
        }

        private void RemovePlayerWithLeastPoints(IList<IPlayer> players)
        {
            int leastPoints = players.Min(p => p.Points);
            var playerWithLeastPoints = players.Single(p => p.Points == leastPoints);
            players.Remove(playerWithLeastPoints);
        }

        private IList<IPlayer> SortPlayersByPoints(IList<IPlayer> players)
        {
            return players.OrderByDescending(p => p.Points).ToList();
        }
    }
}
