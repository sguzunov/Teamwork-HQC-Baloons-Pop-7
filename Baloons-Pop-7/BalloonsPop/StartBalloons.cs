namespace Balloons
{
    using System;
    using System.Linq;

    using Balloons.Commands;
    using Balloons.FieldFactory;
    using Balloons.UI;
    using Balloons.GamePlayer;
    using Balloons.FieldFactory.Field;
    using Balloons.Common;
    using System.Text;
    using Balloons.Logic;
    using Balloons.GameRules;
    using Balloons.InputHandler;

    public class StartBalloons
    {
        public static void Main(string[] args)
        {          
            Facade.StartGame();
        }

    }
}
