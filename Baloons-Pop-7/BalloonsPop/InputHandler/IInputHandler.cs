namespace Balloons.InputHandler
{
    using System.Collections.Generic;

    using Balloons.Common;
    using Balloons.FieldFactory.Field;

    public interface IInputHandler
    {
        IList<string> ReadInputCommand();

        IList<string> ParseInput(IList<string> commands, IGameField field);

        GameMode GetGameMode();

        GameDifficulty GetGameDifficulty();
    }
}
