namespace Balloons.Common
{
    public static class GameMessages
    {
        // New Constants
        public const string InitialGameMessage = "Welcome to 'Balloons Pops' game. Try to pop all the balloons. Use the following commands:";

        public const string EndGameMessage = "Goodbye";

        public const string TopScoresMessage = "Top players: ";

        public const string EmptyScoreBoardMessage = "No players saved.";
        
        public static string[] CommandsMessages = new string[] 
        { 
            "'top' - View the top scores.", 
            "'restart' - Start a new game.",
            "'save' - Save current field state.",
            "'restore' - Restore last saved field state.",
            "'help' - List all game commands.",
            "'exit' - End game.",
        };
    }
}
