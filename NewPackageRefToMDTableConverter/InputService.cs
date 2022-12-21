using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NewPackageRefToMDTableConverter
{
    public class InputService
    {
        public string UserInput { get; set; }
        private Logger _logger;

        public InputService(Logger logger)
        {
            _logger = logger;
        }

        public void SetUserInput()
        {
            Console.Write("Input path: ");
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input) || !Directory.Exists(input))
            {
                UserInput = "";
                _logger.LogWarning("Input is invalid. Empty / White space or directory doesn't exist");
            }
            else
            {
                UserInput = input;
            }
        } 
    }
}
