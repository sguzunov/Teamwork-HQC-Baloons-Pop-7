namespace Balloons.Common
{
    public static class GameMessages
    {
        // New Constants
        public const string InitialGameMessage = "Welcome to 'Balloons Pops' game. Try to pop all the balloons. Use the following commands:";

        public static string[] CommandsMessages = new string[] { 
            "'top' - View the top scores.", 
            "'restart' - Start a new game." ,
            "'save' - Save current field state.",
            "'restore' - Restore last saved field state.",
            "'help' - List all game commands.",
            "'exit' - End game.",
        };

        
        // Old constants
        public const string INITIAL_GAME_MESSAGE =
            "Welcome to 'Balloons Pops' game.\nTry to pop all the balloons.\nUse the commands:\n -> 'top' - to view the top scoreboard,\n -> 'restart' - to start a new game \n -> 'exit' - to quit the game.\n";

        public const string END_GAME_MESSAGE = "Goodbye";

        public const string INVALID_COMMAND_MESSAGE = "Invalid command inserted!";

        public const string INVALID_MOVE_MESSAGE = "Invalid cell selected. Cannot pop missing ballon!";

        public const string CELL_INPUT_MESSAGE = "Enter a row and column: ";
    }
}
