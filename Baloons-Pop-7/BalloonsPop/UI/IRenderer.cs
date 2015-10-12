namespace Balloons.UI
{
    using System.Collections.Generic;

    using Balloons.FieldFactory.Field;
    using Balloons.GamePlayer;

    /// <summary>
    /// Provides all methods every game renderer must have.
    /// </summary>
    public interface IRenderer
    {
        /// <summary>
        /// Provides a method interface for printing the game matrix.
        /// </summary>
        /// <param name="field">Having the matrix for rendering.</param>
        void RenderGameField(IGameField field);

        /// <summary>
        /// Provides a method interface for printing the game messages.
        /// </summary>
        /// <param name="message">The string to render.</param>
        void RenderGameMessage(string message);

        /// <summary>
        /// Provides a method interface for printing the game command.
        /// </summary>
        /// <param name="commands">The game commands.</param>
        void RenderCommands(string[] commands);

        /// <summary>
        /// Provides a method interface for printing the players info.
        /// </summary>
        /// <param name="players">The players played the game.</param>
        void RenderGameTopPlayers(IList<IPlayer> players);

        /// <summary>
        /// Provides a method interface for printing error messages.
        /// Prints the message in different color.
        /// </summary> 
        /// <param name="message">The message which has to be printed in different color.</param>
        void RenderGameErrorMessage(string message);
    }
}
