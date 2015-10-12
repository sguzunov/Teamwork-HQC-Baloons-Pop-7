namespace Balloons.InputHandler
{
    using Balloons.Common;

    /// <summary>
    /// Interface for all classes which can provide game with input values.
    /// </summary>
    public interface IInputHandler
    {
        /// <summary>
        /// Interface representing reading the game command.
        /// </summary>
        /// <returns>Command in a string format.</returns>
        string ReadInputCommand();

        /// <summary>
        /// Interface representing reading the game mode.
        /// </summary>
        /// <returns>Mode converted to enumeration.</returns>
        GameMode GetGameMode();

        /// <summary>
        /// Interface representing reading the game difficulty.
        /// </summary>
        /// <returns>Difficulty converted to enumeration.</returns>
        GameDifficulty GetGameDifficulty();

        /// <summary>
        /// Interface representing reading the player info for managing score statistics.
        /// </summary>
        /// <returns>Player info read.</returns>
        string ReadPlayerInfo();

        /// <summary>
        /// Interface representing reading the player answer for starting new game.
        /// </summary>
        /// <returns>Player answer converted to enumeration.</returns>
        AnotherRound GetPlayAgainResponse();
    }
}
