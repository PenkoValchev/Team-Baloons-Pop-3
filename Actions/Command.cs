namespace BalloonsPops.Actions
{
    public class Command
    {
        public const string TOP = "top";
        public const string RESTART = "restart";
        public const string EXIT = "exit";

        public string Name { get; set; }

        public static bool TryParse(string input, ref Command result)
        {
            if (input == TOP)
            {
                result.Name = input;
                return true;
            }

            if (input == RESTART)
            {
                result.Name = input;
                return true;
            }

            if (input == EXIT)
            {
                result.Name = input;
                return true;
            }

            return false;
        }
    }
}