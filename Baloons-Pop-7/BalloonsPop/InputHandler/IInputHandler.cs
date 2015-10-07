namespace Balloons.InputHandler
{
    using Balloons.Common;
    using Balloons.FieldFactory.Field;
    using System.Collections.Generic;

    public interface IInputHandler
    {
        IList<string> ReadInputCommand();

        IList<string> ParseInput(IList<string> commands, IGameField field);

        GameMode GetGameMode();

        GameDifficulty GetGameDifficulty();
    }
}
