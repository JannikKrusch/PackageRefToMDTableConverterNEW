namespace NewPackageRefToMDTableConverter
{
    public class InputService
    {
        public string Path { get; set; }
        public bool Separate { get; set; }
        public bool Log { get; set; }
        private Logger _logger;

        public InputService(Logger logger)
        {
            _logger = logger;
        }

        public void SetUserInput()
        {
            SetPath();
            Separate = GetTrueOrFalse("Separate package and project references [Y/N]? ");
            Log = GetTrueOrFalse("Show log messages[Y/N]? ");
        }

        public void SetPath()
        {
            while (true)
            {
                Console.Write("Path: ");
                var input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input) && Directory.Exists(input))
                {
                    Path = input;
                    return;
                }

                _logger.LogWarning("Input is invalid. Empty / White space or directory doesn't exist");
            }
        }

        public bool GetTrueOrFalse(string inputMessage)
        {
            while (true)
            {
                Console.Write(inputMessage);
                var input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input) && (input.ToLower() == "y" || input.ToLower() == "n"))
                {
                    return input.ToLower() == "y";
                }

                _logger.LogWarning($"Invalid input. Must be [Y/N]");
            }
        }
    }
}