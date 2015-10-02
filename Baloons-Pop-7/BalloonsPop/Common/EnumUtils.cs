namespace Balloons.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class EnumUtils
    {
        public static IEnumerable<T> GetEnumValues<T>()
        {
            var collection = Enum.GetValues(typeof(T)).Cast<T>();
            return collection;
        }

        public static GameMode GetGameModeFromString(string modeAsString)
        {
            var modes = GetEnumValues<GameMode>();

            var gameMode = modes.FirstOrDefault(m => m.ToString().ToLower() == modeAsString);

            //foreach (var mode in modes)
            //{
            //    var modeConvertedToString = mode.ToString().ToLower();
            //    if (modeAsString == modeConvertedToString)
            //    {
            //        gameMode = mode;
            //    }
            //}

            return gameMode;
        }

        public static GameDifficulty GetGameDifficultyFromString(string difficultyAsString)
        {
            var difficulties = GetEnumValues<GameDifficulty>();

            var difficulty = difficulties.FirstOrDefault(d => d.ToString().ToLower() == difficultyAsString);

            //foreach (var difficulty in difficulties)
            //{
            //    var difficultyConvertedToString = difficulty.ToString().ToLower();
            //    if (difficultyAsString == difficultyConvertedToString)
            //    {
            //        return difficulty;
            //    }
            //}

            return difficulty;
        }
    }
}
