namespace Balloons.GamePlayer
{
    using System;

    public class Player : IPlayer
    {
        private const string PlayerNameNullErrorMessage = "Player name cannot be null!";
        private const string PlayerMovesNegativeCountErrorMessage = "Player moves cannot be negative!";
        private const string PlayerDefaultName = "Player";
        private const int PlayerDefaultMoves = 0;

        private string name;
        private int moves;

        public Player()
            : this(PlayerDefaultName, PlayerDefaultMoves)
        {
        }

        public Player(string name, int moves)
        {
            this.Name = name;
            this.Moves = moves;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(PlayerNameNullErrorMessage);
                }

                this.name = value;
            }
        }

        public int Moves
        {
            get
            {
                return this.moves;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(PlayerMovesNegativeCountErrorMessage);
                }

                this.moves = value;
            }
        }
    }
}
