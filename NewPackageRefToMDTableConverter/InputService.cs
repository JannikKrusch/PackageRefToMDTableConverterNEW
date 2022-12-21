namespace NewPackageRefToMDTableConverter
{
    public class InputService
    {
        public string Path { get; set; }
        public bool Separate { get; set; }
        private Logger _logger;

        public InputService(Logger logger)
        {
            _logger = logger;
        }

        public void SetPath()
        {
            //Console.Write("Input path: ");
            //var input = Console.ReadLine();

            //if (string.IsNullOrWhiteSpace(input) || !Directory.Exists(input))
            //{
            //    Path = "";
            //    _logger.LogWarning("Input is invalid. Empty / White space or directory doesn't exist");
            //}
            //else
            //{
            //    Path = input;
            //}

            while (true)
            {
                Console.Write("Input path: ");
                var input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input) && Directory.Exists(input))
                {
                    Path = input;
                    return;
                }

                _logger.LogWarning("Input is invalid. Empty / White space or directory doesn't exist");
            }
        }

        public void SetSeparate()
        {
            while (true)
            {
                Console.Write("Separate package and project references into different tables [Y/N]? ");
                var input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input) && (input.ToLower() == "y" || input.ToLower() == "n"))
                {
                    Separate = input.ToLower() == "y" ? true : false;
                    return;
                }

                _logger.LogWarning($"Invalid input. Must be [Y/N]");
            }
        }
    }
}