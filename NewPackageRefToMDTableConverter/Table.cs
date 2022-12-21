using System.Text;

namespace NewPackageRefToMDTableConverter
{
    public class Table
    {
        private Logger _logger;
        private StringBuilder _sb;

        public Table(Logger logger)
        {
            _logger = logger;
            _sb = new StringBuilder();
        }

        public List<List<string>> CreateTables(List<List<PackageRef>> packageRefs)
        {
            _logger.LogDebug("Started creating tables");

            var tables = new List<List<string>>();
            foreach (var packageRef in packageRefs)
            {
                tables.Add(CreateTable(packageRef));
            }

            _logger.LogDebug("Finished creating tables");

            return tables;
        }

        public List<string> CreateTable(List<PackageRef> packageRefs)
        {
            var table = new List<string>();
            var lengthofPackage = GetLongestPackageLength(packageRefs);
            var lengthOfVersion = GetLongestVersionLength(packageRefs);

            table.Add(CreateHeader(lengthofPackage, lengthOfVersion));
            table.Add(CreatePartinLine(lengthofPackage, lengthOfVersion));

            foreach (var packageRef in packageRefs)
            {
                table.Add(CreateRow(packageRef, lengthofPackage, lengthOfVersion));
            }

            return table;
        }

        public string CreateHeader(int lengthOfPackage, int lengthOfVersion)
        {
            return $"| Package{new string(' ', lengthOfPackage - "Package".Length)} | Version{new string(' ', lengthOfVersion - "Version".Length)} |";
        }

        public string CreatePartinLine(int lengthOfPackage, int lengthOfVersion)
        {
            return $"| {new string('-', lengthOfPackage)} | {new string('-', lengthOfVersion)} |";
        }

        public string CreateRow(PackageRef packageRef, int lengthOfPackage, int lengthOfVersion)
        {
            return $"| {packageRef.Package}{new string(' ', lengthOfPackage - packageRef.Package.Length)} | {packageRef.Version}{new string(' ', lengthOfVersion - packageRef.Version.Length)} |";
        }

        public int GetLongestPackageLength(List<PackageRef> packageRefs)
        {
            return Math.Max(packageRefs.Max(x => x.Package.Length), "Package".Length);
        }

        public int GetLongestVersionLength(List<PackageRef> packageRefs)
        {
            return Math.Max(packageRefs.Max(x => x.Version.Length), "Version".Length);
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
            foreach (var item in table)
            {
                Console.WriteLine(item);
            }
        }
    }
}