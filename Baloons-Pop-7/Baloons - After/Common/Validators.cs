
namespace Baloons.Common
{
    using System;

    public static class Validator
    {
        public static void CheckIfNameIsEmpty(string name)  // Commands.StatisticsCommand
        {
            if (name == " ")
            {
                throw new NullReferenceException("Name can not be empty");
            }
        }
        public static void CheckLenghtOfName(string name) // Commands.StatisticsCommand
        {
            if (name.Length > 3 || name.Length <= 10)
            {
                throw new IndexOutOfRangeException("Name must be between 3 and 10 chars");
            }
        }

    }
}
