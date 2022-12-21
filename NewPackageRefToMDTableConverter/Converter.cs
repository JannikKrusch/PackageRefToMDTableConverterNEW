namespace NewPackageRefToMDTableConverter
{
    public class Converter
    {
        private Logger _logger;
        private Table _table;
        private List<string> _projectNames;

        public Converter(Logger logger)
        {
            _logger = logger;
            _table = new Table(logger);
            _projectNames = new List<string>();
        }

        public void StartConverting(string path)
        {
            var referenceFiles = GetReferenceFiles(path);
            var filteredFiles = new List<List<string>>();

            foreach (var referenceFile in referenceFiles)
            {
                filteredFiles.Add(FilterFile(referenceFile));
            }

            var referencesList = ConvertToReferenceList(filteredFiles);
            var tables = _table.CreateTables(referencesList);
            _table.PrintTables(tables, _projectNames);
        }

        public List<List<string>> GetReferenceFiles(string path)
        {
            var projectsDirs = Directory.GetDirectories(path).ToList();
            var projectRefFiles = new List<List<string>>();
            var amountOfProjectsWithFile = 0;
            foreach (var projectDir in projectsDirs)
            {
                var filePath = (Directory.GetFiles(projectDir).Where(file => file.EndsWith(".csproj")).FirstOrDefault());
                if (filePath != null)
                {
                    projectRefFiles.Add(File.ReadAllLines(filePath).ToList());
                    _logger.LogDebug($"Added file to list {filePath}");
                    amountOfProjectsWithFile++;

                    var splitDir = projectDir.Split("\\");
                    _projectNames.Add(splitDir[splitDir.Length - 1]);
                }
                else
                {
                    _logger.LogWarning($"Could't get file path for project: {projectDir}");
                }
            }

            _logger.LogInfo($".csproj files found counter: {amountOfProjectsWithFile}");
            _logger.LogInfo($"Project counter: {projectsDirs.Count}");
            Console.WriteLine(new string('-', 40));

            return projectRefFiles;
        }

        public List<string> FilterFile(List<string> file)
        {
            var filteredLines = new List<string>();
            foreach (var line in file)
            {
                var trimmedLine = line.Trim();
                if (trimmedLine.StartsWith("<PackageReference Include=") || trimmedLine.StartsWith("<ProjectReference Include=") && trimmedLine.EndsWith("/>"))
                {
                    filteredLines.Add(trimmedLine);
                }
            }

            return filteredLines;
        }

        public List<List<Reference>> ConvertToReferenceList(List<List<string>> filteredProjectFiles)
        {
            var referencesList = new List<List<Reference>>();
            foreach (var project in filteredProjectFiles)
            {
                _logger.LogDebug("Creating PackageReference list");
                var projectReferences = new List<Reference>();

                foreach (var line in project)
                {
                    projectReferences.Add(ConvertToReference(line));
                }
                referencesList.Add(projectReferences);
            }

            return referencesList;
        }

        public Reference ConvertToReference(string line)
        {
            _logger.LogDebug("Creating PackageReference item");

            var packageRef = new Reference();
            var splitLine = line.Split(" ");

            if (line.StartsWith("<PackageReference Include="))
            {
                //package mit version
                packageRef.Name = splitLine[1].Replace("Include=\"", "").Replace("\"", "");
                packageRef.Version = splitLine[2].Replace("Version=\"", "").Replace("\"", "");
            }
            else
            {
                //project ohne version
                packageRef.Name = splitLine[1].Replace("Include=\"", "").Replace("\"", "");
                packageRef.Version = "";
            }
            return packageRef;
        }
    }
}