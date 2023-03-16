using NewPackageRefToMDTableConverter;

Console.WriteLine("Package reference converter is starting ... start");

var logger = new Logger();
var inputService = new InputService(logger);
var converter = new Converter(logger);

inputService.SetPath();
if(!string.IsNullOrEmpty(inputService.Path))
{
    converter.StartConverting(inputService.Path);
}
