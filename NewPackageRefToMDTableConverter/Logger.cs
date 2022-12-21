namespace NewPackageRefToMDTableConverter
{
    public class Logger
    {
        public void LogInfo(string message)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"INFO:\t{message}");
            Console.ForegroundColor = color;
        }

        public void LogDebug(string message)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"DEBUG:\t{message}");
            Console.ForegroundColor = color;
        }

        public void LogWarning(string message)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"WARNING:\t{message}");
            Console.ForegroundColor = color;
        }
    }
}