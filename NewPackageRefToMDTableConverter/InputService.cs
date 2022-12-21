namespace NewPackageRefToMDTableConverter
{
    public class InputService
    {
        public string Path { get; set; }
        private Logger _logger;

        public InputService(Logger logger)
        {
            _logger = logger;
        }

        public void SetPath()
        {
            Console.Write("Input path: ");
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input) || !Directory.Exists(input))
            {
                Path = "";
                _logger.LogWarning("Input is invalid. Empty / White space or directory doesn't exist");
            }
            else
            {
                Path = input;
            }
        } 
    }
}
