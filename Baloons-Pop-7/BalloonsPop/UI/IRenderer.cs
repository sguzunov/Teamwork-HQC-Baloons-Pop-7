namespace Balloons.UI
{
    using Balloons.FieldFactory.Field;
    using System.Collections.Generic;
    using Balloons.GamePlayer;

    public interface IRenderer
    {
        void RenderGameField(IGameField field);

        void RenderMenu();

        void RenderCommands(string[] commands);

        void RenderGameTopPlayers(IList<IPlayer> players);

        void RenderGameMessage(string message);
    }
}
