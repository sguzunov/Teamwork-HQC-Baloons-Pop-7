namespace Balloons.Common
{
    using System;
    using System.Linq;

    public static class Validator
    {
        private const int MinNameLength = 2;
        private const int MaxNameLength = 20;

        // Commands.StatisticsCommand
        public static void CheckIfNameIsEmpty(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new NullReferenceException("Name can not be empty");
            }
        }

        // Commands.StatisticsCommand
        public static void CheckLenghtOfName(string name)
        {
            if (name.Length > MinNameLength || name.Length <= MaxNameLength)
            {
                throw new IndexOutOfRangeException("Name must be between " + MinNameLength + " and " + MaxNameLength + " chars");
            }
        }

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
