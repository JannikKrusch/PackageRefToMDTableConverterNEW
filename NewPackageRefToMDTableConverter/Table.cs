using NewPackageRefToMDTableConverter.Models;

namespace NewPackageRefToMDTableConverter
{
    public class Table
    {
        private Logger _logger;

        public Table(Logger logger)
        {
            _logger = logger;
        }

        public List<List<string>> CreateTables(List<List<Reference>> referencesList)
        {
            _logger.LogDebug("Started creating tables");

            var tables = new List<List<string>>();
            foreach (var references in referencesList)
            {
                tables.Add(CreateTable(references));
            }

            _logger.LogDebug("Finished creating tables");

            return tables;
        }

        public List<string> CreateTable(List<Reference> references)
        {
            var table = new List<string>();
            var lengthOfName = GetLongestNameLength(references);
            var lengthOfVersion = GetLongestVersionLength(references);

            table.Add(CreateHeader(lengthOfName, lengthOfVersion));
            table.Add(CreatePartingLine(lengthOfName, lengthOfVersion));

            foreach (var reference in references)
            {
                table.Add(CreateRow(reference, lengthOfName, lengthOfVersion));
            }

            return table;
        }

        public string CreateHeader(int lengthOfName, int lengthOfVersion)
        {
            return $"| Reference{new string(' ', lengthOfName - "Reference".Length)} | Version{new string(' ', lengthOfVersion - "Version".Length)} |";
        }

        public string CreatePartingLine(int lengthOfName, int lengthOfVersion)
        {
            return $"| {new string('-', lengthOfName)} | {new string('-', lengthOfVersion)} |";
        }

        public string CreateRow(Reference reference, int lengthOfName, int lengthOfVersion)
        {
            return $"| {reference.Name}{new string(' ', lengthOfName - reference.Name.Length)} | {reference.Version}{new string(' ', lengthOfVersion - reference.Version.Length)} |";
        }

        public int GetLongestNameLength(List<Reference> references)
        {
            return Math.Max(references.Max(x => x.Name.Length), "Reference".Length);
        }

        public int GetLongestVersionLength(List<Reference> references)
        {
            return Math.Max(references.Max(x => x.Version.Length), "Version".Length);
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