namespace Balloons.Common
{
    using System;
    using System.Linq;

    public static class Validator
    {
        public static bool CheckIfValidGameMode(string gameMode)
        {
            if (gameMode == null)
            {
                return false;
            }

            var modes = EnumUtils.GetEnumValues<GameMode>();
            var isValidMode = modes.Any(m => m.ToString().ToLower() == gameMode);

            return isValidMode;
        }

        public static bool CheckIfValidGameDifficulty(string gameDifficulty)
        {
            if (gameDifficulty == null)
            {
                return false;
            }

            var difficulties = EnumUtils.GetEnumValues<GameDifficulty>();
            var isValidDifficulty = difficulties.Any(d => d.ToString().ToLower() == gameDifficulty);

            return isValidDifficulty;
        }

        public static bool CheckIfStringIsNullOrWhiteSpace(string context)
        {
            if (string.IsNullOrWhiteSpace(context))
            {
                return true;
            }

            return false;
        }
    }
}
