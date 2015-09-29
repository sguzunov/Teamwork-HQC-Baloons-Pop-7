namespace Balloons.Common
{
    using System;

    public static class Validator
    {
        public const int MinNameLength = 2;
        public const int MaxNameLength = 20;

        public static void CheckIfNameIsEmpty(string name)  // Commands.StatisticsCommand
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new NullReferenceException("Name can not be empty");
            }
        }

        public static void CheckLenghtOfName(string name) // Commands.StatisticsCommand
        {
            if (name.Length > MinNameLength || name.Length <= MaxNameLength)
            {
                throw new IndexOutOfRangeException("Name must be between " + MinNameLength + " and " + MaxNameLength + " chars");
            }
        }
    }
}
