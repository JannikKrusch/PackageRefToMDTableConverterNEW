namespace NewPackageRefToMDTableConverter
{
    public class Logger
    {
        public bool Log { get; set; }

        public Logger()
        {
            Log = true;
        }

        public void LogInfo(string message)
        {
            if (Log)
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"INFO:\t{message}");
                Console.ForegroundColor = color;
            }        }

        public void LogDebug(string message)
        {
            if (Log)
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"DEBUG:\t{message}");
                Console.ForegroundColor = color;
            }
        }

        public void LogWarning(string message)
        {
            if (Log)
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"WARNING:\t{message}");
                Console.ForegroundColor = color;
            }
        }
    }
}