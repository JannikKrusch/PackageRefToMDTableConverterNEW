// See https://aka.ms/new-console-template for more information
using NewPackageRefToMDTableConverter;

Console.WriteLine("Hello, World!");

var logger = new Logger();
var inputService = new InputService(logger);
var converter = new Converter(logger);

inputService.SetPath();
if(inputService.Path != "")
{
    converter.StartConverting(inputService.Path);
}
