namespace BalloonsPops.Common.Actions
{
    using System;

    public static class Command
    {
        public static bool IsValidType(string input)
        {
            CommandTypes currentType;
            
            int inputAsInt;
            bool isInputInteger = int.TryParse(input, out inputAsInt);

            if (!isInputInteger)
            {
                bool isCorrectEnum = Enum.TryParse(input, true, out currentType);

                if (isCorrectEnum)
                {
                    return true;
                }
            }

            return false;
        }
    }
}