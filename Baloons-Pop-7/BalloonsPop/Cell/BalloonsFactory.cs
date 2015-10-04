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
                        balloon = balloons[symbol];
                        break;
                    }
                case "2":
                    {
                        balloon = balloons[symbol];
                        break;
                    }
                case "3":
                    {
                        balloon = balloons[symbol];
                        break;
                    }
                case "4":
                    {
                        balloon = balloons[symbol];
                        break;
                    }
                case ".":
                    {
                        balloon = balloons[symbol];
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
