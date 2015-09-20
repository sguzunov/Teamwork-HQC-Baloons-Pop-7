namespace Balloons.Common
{
    public static class GameMessages
    {
        public const string INITIAL_GAME_MESSAGE = 
            "Welcome to 'Balloons Pops' game.\nTry to pop all the balloons.\nUse the commands:\n -> 'top' - to view the top scoreboard,\n -> 'restart' - to start a new game \n -> 'exit' - to quit the game.\n";

        public const string END_GAME_MESSAGE = "Goodbye";

        public const string INVALID_COMMAND_MESSAGE = "Invalid command inserted!";

        public const string INVALID_MOVE_MESSAGE = "Invalid cell selected. Cannot pop missing ballon!";

        public const string CELL_INPUT_MESSAGE = "Enter a row and column: ";
    }
}
