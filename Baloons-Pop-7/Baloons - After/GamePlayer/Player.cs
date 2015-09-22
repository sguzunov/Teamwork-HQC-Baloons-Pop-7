using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balloons.GamePlayer
{
    public class Player : IPlayer
    {
        public Player(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }

        public string Name
        {
            get;
            set;
        }

        public int Points
        {
            get;
            set;
        }
    }
}
