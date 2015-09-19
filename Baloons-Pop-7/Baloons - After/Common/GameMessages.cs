namespace Balloons.Common
{
    public static class GameMessages
    {
        public const string INITIAL_GAME_MESSAGE = "Welcome to 'Balloons Pops' game. Try to pop all the balloons. Use commands 'top' - to view the top scoreboard, 'restart' - to start a new game and 'exit' - to quit the game.";

        public const string END_GAME_MESSAGE = "Goodbye";

        public const string INVALID_COMMAND_MESSAGE = "Invalid command inserted!";

        public const string INVALID_MOVE_MESSAGE = "Invalid cell selected. Cannot pop missing ballon!";

        public const string CELL_INPUT_MESSAGE = "Enter a row and column: ";
    }
}
