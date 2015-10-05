using System;
using System.Collections.Generic;

namespace Balloons.Cell
{
    public class BalloonsFactory
    {
        private const string BalloonSymbolErrorMessage = "Ballon with {0} symbol does not exists.";

        private readonly IDictionary<string, Balloon> balloons = new Dictionary<string, Balloon>();

        public Balloon GetBalloon(string symbol)
        {
            if (balloons.ContainsKey(symbol))
            {
                return balloons[symbol];
            }

            Balloon balloon;
            switch (symbol)
            {
                case "1":
                    {
                        balloon = new BalloonOne();
                        break;
                    }
                case "2":
                    {
                        balloon = new BalloonTwo();
                        break;
                    }
                case "3":
                    {
                        balloon = new BalloonThree();
                        break;
                    }
                case "4":
                    {
                        balloon = new BalloonFour();
                        break;
                    }
                case ".":
                    {
                        balloon = new BalloonPoped();
                        break;
                    }
                default:
                    {
                        throw new ArgumentException(string.Format(BalloonSymbolErrorMessage, symbol));
                    }
            }

            this.balloons.Add(symbol, balloon);

            return balloon;
        }
    }
}
