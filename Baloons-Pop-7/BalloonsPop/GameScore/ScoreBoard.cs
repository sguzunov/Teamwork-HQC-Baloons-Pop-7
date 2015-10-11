namespace Balloons.GameScore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Balloons.GamePlayer;

    public class ScoreBoard
    {
        private const int MaxPossiblePlayers = 5;
        private const string PlayerNullErrorMessage = "New player cannot be null.";

        private static readonly object SyncLock = new object();

        private static ScoreBoard instance;
        private readonly IList<IPlayer> listOfPlayers;

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
                    lock (SyncLock)
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
                var sortedPlayers = this.SortPlayersAscendingByMoves(this.listOfPlayers);
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
                this.RemovePlayerWithLeastMostMoves(this.listOfPlayers);
            }
        }

        private void RemovePlayerWithLeastMostMoves(IList<IPlayer> players)
        {
            int mostPoints = players.Max(p => p.Moves);
            var playerWithMostMoves = players.Single(p => p.Moves == mostPoints);
            players.Remove(playerWithMostMoves);
        }

        private IList<IPlayer> SortPlayersAscendingByMoves(IList<IPlayer> players)
        {
            return players.OrderBy(p => p.Moves).ToList();
        }
    }
}
