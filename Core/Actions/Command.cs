namespace BalloonsPops.Core.Actions
{
    using System;

    public static class Command
    {
        public static bool IsValidType(string input)
        {
            CommandTypes currentType;
            bool isCorrectEnum = Enum.TryParse(input, true, out currentType);

            if (isCorrectEnum)
            {
                return true;
            }

            return false;
        }
    }
}