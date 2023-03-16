using NewPackageRefToMDTableConverter.Models;

namespace NewPackageRefToMDTableConverter
{
    public class TableProvider
    {
        private Logger _logger;

        public TableProvider(Logger logger)
        {
            _logger = logger;
        }

        public List<List<string>> CreateTables(List<List<Reference>> referencesList)
        {
            _logger.LogDebug("Started creating tables");

            var tables = referencesList
                .Select(r => CreateTable(r))
                .ToList();

            _logger.LogDebug("Finished creating tables");

            return tables;
        }

        public List<string> CreateTable(List<Reference> references)
        {
            var table = TableFactory.Create(references);

            return table.Lines;
        }

        public void PrintTables(List<List<string>> tables, List<string> projectNames)
        {
            _logger.LogInfo("Starting printing tables");

            var counter = 1;
            foreach (var table in tables)
            {
                _logger.LogDebug($"Table {counter}/{tables.Count}");
                Console.WriteLine($"### {projectNames[counter - 1]}\n");
                PrintTable(table);
                Console.WriteLine("\n");
                counter++;
            }

            _logger.LogInfo("Finished printing tables");
        }

        public void PrintTable(List<string> table)
        {
            foreach (var row in table)
            {
                Console.WriteLine(row);
            }
        }
    }
}